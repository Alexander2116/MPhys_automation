﻿/*============================================================
**
** Class:  HR550
**
** Purpose: Connect to Horiba iHR550 spectrometer
**        : Control the spectrometer (inc. shutter)
**
**         : All the data will be stored in DataTable dData
*          : you can access it using list<double> methods
*          
** Comments: This is taken from Mono_Cs_NET example from SDK
**
** Date:  24 February 2023
**
===========================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

using JYMONOLib;
using JYCONFIGBROWSERCOMPONENTLib;
using JYSYSTEMLIBLib;
using JYCCDLib;
using System.Drawing;
using MPhys.MyFunctions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MPhys.Devices
{

    class HR550_c
    {
        private Boolean mbEmulate;
        private Boolean mbForceInit;
        private Boolean mbInitialized;
        private Boolean mbPositionChanged;
        private Boolean mbSlitFrontEntranceChanged;
        private Boolean mbSlitSideEntranceChanged;
        private Boolean mbSlitFrontExitChanged;
        private Boolean mbSlitSideExitChanged;
        private String sMonoDevId;
        private String sMonoName;
        private String sCCDId;
        private String sCCDName;

        private DataTable dData;

        // Should be private, may change it later
        public JYConfigBrowerInterface mConfigBrowser;
        public JYMONOLib.MonochromatorClass mMono;

        // CCD
        //public JYCCDLib.JYMCDClass mCCD;
        public JYSYSTEMLIBLib.IJYDataObject ccdData;
        public JYSYSTEMLIBLib.IJYResultsObject ccdResult;
        public JYCCDLib.JYMCDClass mCCD;

        // jyCCD = new JYCCDLib.JYMCDClass();
        // jyMono = new JYMONOLib.MonochromatorClass();

        String sDevId;
        String sDevName;
        String SCD; // SCDid

        // Lists for ComboBoxes
        public List<SCDid> combobox_Mono = new List<SCDid>(); // Upload list to ComboBox in the form
        public List<SCDid> combobox_CCD = new List<SCDid>(); // Upload list to ComboBox in the form
        public List<double> combobox_Grating = new List<double>(); // List of gratings
        public List<ADCStringType> combobox_ADC; // List of available ADC
        public List<PairStringInt> combobox_Gain; // List of available ADC
        /*
                 public List<ADCStringType> combobox_ADC = new List<ADCStringType>(); // List of available ADC
        public List<PairStringInt> combobox_Gain = new List<PairStringInt>(); // List of available ADC*/

        //
        public String Text_CurrentWavelength;

        // Slits 
        public String Text_Slit_Front_Entrance = "";
        public String Text_Slit_Front_Exit = "";
        public String Text_Slit_Side_Entrance = "";
        public String Text_Slit_Side_Exit = "";

        // Mirrors
        public Boolean Radio_Entrance_Axial = false;
        public Boolean Radio_Entrance_Lateral = false;
        public Boolean Radio_Exit_Axial = false;
        public Boolean Radio_Exit_Lateral = false;

        MyFunctionsClass myFunc = new MyFunctionsClass();

        // Initilize, adding all available objects to combobox_list (all available SCDs)
        public HR550_c()
        {
            String sDevId;
            String sDevName;
            SCDid SCD;
            dData = new DataTable();
            SetDataTable();

            try
            {
                mConfigBrowser = new JYConfigBrowerInterface();

                // Load Config Browser
                mConfigBrowser.Load();

                // File Combo Box with Mono devices
                sDevId = mConfigBrowser.GetFirstMono(out sDevName);
                while ((sDevName != null) && (String.Compare(sDevName, "") != 0))
                {
                    // Add Configuration Names and IDs to combo box
                    SCD = new SCDid();
                    SCD.sName = sDevName;
                    SCD.sID = sDevId;
                    combobox_Mono.Add(SCD);

                    // Find the next Mono in this Configuration
                    sDevId = mConfigBrowser.GetNextMono(out sDevName);
                }

                sDevId = mConfigBrowser.GetFirstCCD(out sDevName);
                while ((String.IsNullOrEmpty(sDevName) == false) && (String.IsNullOrEmpty(sDevId) == false))
                {
                    // Add Configuration Names and IDs to combo box
                    SCD = new SCDid();
                    SCD.sName = sDevName;
                    SCD.sID = sDevId;
                    combobox_CCD.Add(SCD);

                    // Find the next Mono in this Configuration
                    sDevId = mConfigBrowser.GetNextCCD(out sDevName);
                }


            }
            catch (SystemException ex)
            {
                // Received Exception: report & exit
                Console.WriteLine(String.Format("Exception: {0}", ex.Message));
                return;
            }
        }

        public void GetModes()
        {
            string mode_name = "";
            myFunc.add_to_log("GetModes", "Modes: ");
            mCCD.GetFirstOperatingMode(out mode_name);
            myFunc.add_to_log("GetModes", mode_name);
            while ((String.IsNullOrEmpty(mode_name) == false))
            {
                mCCD.GetNextOperatingMode(out mode_name);
                myFunc.add_to_log("GetModes", mode_name);
            }
        }

        public void SetDataTable()
        {
            DataColumn column;

            // Wavelength [nm]
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Wavelength";
            column.ReadOnly = false;
            column.Unique = false;
            dData.Columns.Add(column);

            // Intensity [count]
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "Intensity";
            column.ReadOnly = false;
            column.Unique = false;
            dData.Columns.Add(column);
        }

        public List<double> GetWavelengthDataColumn()
        {
            List<double> list = new List<double>();
            for (int i = 0; i < dData.Rows.Count; i++)
            {
                list.Add((double)dData.Rows[i]["Wavelength"]);
            }
            return list;
        }
        public List<double> GetIntensityDataColumn()
        {
            List<double> list = new List<double>();
            for (int i = 0; i < dData.Rows.Count; i++)
            {
                list.Add((double)dData.Rows[i]["Intensity"]);
            }
            return list;
        }

        public bool can_be_initialized()
        {
            try
            {
                mMono = new JYMONOLib.MonochromatorClass();
                mMono = null;
                mCCD = new JYCCDLib.JYMCDClass();
                mCCD = null;

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void InitializeMono(SCDid CurrMono)
        {
            String sStatus;

            // OPEN COMMUNICATIONS

            sMonoName = CurrMono.sName;
            if (sMonoName != "")
            {
                // Create New MonochromatorClass
                mMono = new JYMONOLib.MonochromatorClass();

                mMono.Uniqueid = CurrMono.sID;

                // Set Mono Initialize event handler
                mMono._IJYDeviceReqdEvents_Event_Initialize += OnReceivedInitMono;

                // Loads up the device with the specified configuration
                mMono.Load();

                sStatus = String.Format("Opening Communications ... ");
                Console.WriteLine(sStatus);
                // Attempts to communicate with a device on the specified communication 
                // settings (in the configuration). If it fails, the catch allows the
                // device to be emulated in software.
                mMono.OpenCommunications();

                /*GetPosition();

                GetSlits();
                GetGratings();
                GetMirrors();*/
                GetGratings();

                sStatus = String.Format("Complete{0}", Environment.NewLine);
                Console.WriteLine(sStatus);



                // INITIALIZE
                try
                {
                    sStatus = String.Format("Initializing Mono ... ");
                    Console.WriteLine(sStatus);

                    //if (mbInitialized == true)
                    mbForceInit = true;

                    mMono.Initialize(mbForceInit, mbEmulate, false);
                }
                catch (Exception ex)
                {
                    sStatus = String.Format("{0} Initialize Failed.{1}", sMonoName, Environment.NewLine);
                    Console.WriteLine(sStatus);
                }
            }
        }

        public void InitializeCCD(SCDid CurrCCD)
        {
            String sStatus;

            // OPEN COMMUNICATIONS

            sCCDName = CurrCCD.sName;
            if (sCCDName != "")
            {
                // *** Connect ***
                // Create New Single Channel Detector
                mCCD = new JYCCDLib.JYMCDClass();

                mCCD.Uniqueid = CurrCCD.sID;

                myFunc.add_to_log("InitializeCCD", "CCD Event");
                // Set Mono Initialize event handler - apparently very important 
                mCCD._IJYDeviceReqdEvents_Event_Initialize += OnCCDEvent_Initialized;
                mCCD.OperationStatus += OnCCDEvent_OperationStatus; // empty, but must be present for some reason
                //mCCD.Update += OnCCDEvent_Update;

                myFunc.add_to_log("InitializeCCD", "CCD Load");
                // Loads up the device with the specified configuration
                mCCD.Load();

                //sStatus = String.Format("Opening Communications ... ");
                //Console.WriteLine(sStatus);
                // Attempts to communicate with a device on the specified communication 
                // settings (in the configuration). If it fails, the catch allows the
                // device to be emulated in software.
                myFunc.add_to_log("InitializeCCD", "CCD Open");
                mCCD.OpenCommunications();
                // *** Initialized ***
                myFunc.add_to_log("InitializeCCD", "CCD Initialize");
                mCCD.Initialize(); // mCCD.Initialize(true)

                myFunc.add_to_log("InitializeCCD", "Load ADC and Gain");
                //InitializeADCSelect();
                //InitializeGainSelect();

                sStatus = String.Format("Complete{0}", Environment.NewLine);
                myFunc.add_to_log("InitializeCCD", sStatus);
                //Console.WriteLine(sStatus);
            }
        }

        public void OnCCDEvent_Initialized(int status, JYSYSTEMLIBLib.IJYEventInfo myEvent)
        {
            if (status == 0)
            {
                myFunc.add_to_log("OnCCDEvent_Initialized", "Adding Gain and ADC");
                combobox_Gain = InitializeGainSelect();
                combobox_ADC = InitializeADCSelect();
                InitializeInitIntegration();
                myFunc.add_to_log("OnCCDEvent_Initialized", "Gain and ADC Added");
            }
            else
            {
                myFunc.add_to_log("OnCCDEvent_Initialized", String.Format("Failed{0}", Environment.NewLine));
            }

        }

        private void InitializeInitIntegration()
        {
            double dVal;
            Object oUnits;
            string timeUnits = "";
            jyUnits units = jyUnits.jyuMilliseconds;

            try
            {
                units = jyUnits.jyuUndefined;
                mCCD.GetDefaultUnits(jyUnitsType.jyutTime, out units, out oUnits);
                timeUnits = (String)oUnits;
            }
            catch (Exception ex)
            {
                ex.ToString();
                timeUnits = "?";
            }

            try
            {
                dVal = mCCD.IntegrationTime;
                if (dVal <= 0)
                    dVal = 10;
            }
            catch (Exception ex)
            {
                ex.ToString();
                dVal = 10;
            }
        }

        // Declaration of an event handler for HJY Mono
        public void OnReceivedInitMono(int status, JYSYSTEMLIBLib.IJYEventInfo myEvent)
        {
            String sStatus;
            jyUnits Units;
            Object oUnitsString;


            if (status == 0)
            {
                mbInitialized = true;

                sStatus = String.Format("Complete{0}", Environment.NewLine);
                Console.WriteLine(sStatus);

                GetPosition();

                GetSlits();
                GetGratings();
                GetMirrors();

                //Application.DoEvents();


                mMono.GetDefaultUnits(jyUnitsType.jyutSlitWidth, out Units, out oUnitsString);
            }
            else
            {
                sStatus = String.Format("Failed{0}", Environment.NewLine);
                Console.WriteLine(sStatus);
            }

        }

        // Open/Close shutter
        public void Close_Shutter()
        {
            if (mMono != null)
            {
                try
                {
                    mMono.CloseShutter();
                }
                catch
                {
                    Console.WriteLine("Shutter Close Fail");
                }
            }
            else
            {
                Console.WriteLine("Shutter Close Fail - not initialized");
            }

        }
        public void Open_Shutter()
        {
            if (mMono != null)
            {
                try
                {
                    mMono.OpenShutter();
                }
                catch
                {
                    Console.WriteLine("Shutter Open Fail");
                }
            }
            else
            {
                Console.WriteLine("Shutter Open Fail - not initialized");
            }
        }

        public bool MonoIsBusy()
        {
            return mMono.IsBusy();
        }

        public void SetIntegrationTime(double IntTime = 2)
        {
            mCCD.IntegrationTime = IntTime;
        }

        //=================================
        // begin streaming mode
        // total count - 
        // streaming - mode: 1, 2, 3.
        // Mode 2 and 3 are almost the same (saves file somewhere)
        //=================================
        public void GoStream(string path, int total_count = 1, int streaming = 2)
        {
            int counter;
            String fname;
            Boolean busy;
            Object dataArray;

            counter = 1;
            myFunc.add_to_log("GoStream", "GoStream() Called");
            myFunc.add_to_log("GoStream", "Creating arrays");
            JYSYSTEMLIBLib.IJYDataObject[] dataarray;
            dataarray = new JYSYSTEMLIBLib.IJYDataObject[total_count];
            myFunc.add_to_log("GoStream", "Arrays created");

            do
            {
                myFunc.add_to_log("GoStream", "Starting acquisition");
                // Start data Acquisition
                mCCD.StartAcquisition(true);
                // wait for data to come in (busy = False)
                do
                {
                    busy = mCCD.AcquisitionBusy();
                    myFunc.add_to_log("GoStream", "AcquisitionBusy"); // Only for testing
                }
                while (busy == true);

                // Get result of data acquisition
                myFunc.add_to_log("GoStream", "Get result");
                ccdResult = mCCD.GetResult();
                // pull off as data object
                myFunc.add_to_log("GoStream", "Get data");
                ccdData = ccdResult.GetFirstDataObject();

                myFunc.add_to_log("GoStream", "Data taken");
                if (streaming == 1)
                {
                    // pull of number of dimensions
                    int numOfDim = ccdData.NumberOfDimensions;
                    // int numXDim = ccdData.Dimensions;
                    int numXDim = ccdData.GetDimension(1);  // x dimension
                    int numYDim = 1;
                    // get y dimension if dimensions > 1
                    if (numOfDim > 1)
                        numYDim = ccdData.GetDimension(2);  // y dimension
                    object test;
                    // pull off data into object (safearray)
                    ccdData.GetDataAsArray(out test);

                    // do something with the data
                }
                if (streaming == 2)
                {
                    // make a copy of data and store in array of data objects
                    dataarray[counter - 1] = ccdData.MakeCopy();
                }

                if (streaming == 3)
                {
                    fname = Path.GetFullPath(path) +
                            Path.GetFileNameWithoutExtension(path) +
                            Convert.ToString(counter) +
                            Path.GetExtension(path);
                    try
                    {
                        // Save each Collection into a unique file
                        myFunc.add_to_log("GoStream", "Saving the data");
                        ccdData.Save(fname);
                        myFunc.add_to_log("GoStream", "The data is saved");
                    }
                    catch
                    {
                        myFunc.add_to_log("GoStream", "Failed to save the data");
                    }
                }

                counter = counter + 1;
            }
            while (counter <= total_count);

            // if streaming to memory, the loop through array and write each image to file
            if (streaming == 2)
            {
                try
                {
                    SaveMultiple(path, dataarray);
                    /*
                    for (counter = 0; counter < total_count; counter++)
                    {
                        fname = Path.GetFullPath(path) +
                                Path.GetFileNameWithoutExtension(path) +
                                Convert.ToString(counter + 1) +
                                Path.GetExtension(path);

                        // Save each Collection into a unique file
                        dataarray[counter].Save(fname);
                    }*/
                }
                catch
                {
                    Console.WriteLine("Couldn't open data file, make sure folder exists");
                }
            }
        }
        public void OnCCDEvent_OperationStatus(int status, JYSYSTEMLIBLib.IJYEventInfo eventInfo)
        {
        }

        //=====================================================
        // save data from ccd as either spc or tab delimited.
        //      filePath = path + /filename.ext
        //=====================================================
        private void SaveMultiple(string filePath, JYSYSTEMLIBLib.IJYDataObject[] dataarray)
        {

            try
            {
                for (int counter = 0; counter < dataarray.Length; counter++)
                {
                    string fname = Path.GetFullPath(filePath) +
                            Path.GetFileNameWithoutExtension(filePath) +
                            Convert.ToString(counter + 1) +
                            Path.GetExtension(filePath);

                    // Save each Collection into a unique file
                    dataarray[counter].Save(fname);
                }
            }
            catch
            {
                Console.WriteLine("Couldn't open data file, make sure folder exists");
            }

            // Save - first implementation
            // String saveFileName;
            // saveFileName = filePath;
            /*
            try
            {
                if (File.Exists(filePath)) //savespc
                {
                    ccdData.FileType = JYSYSTEMLIBLib.jySupportedFileType.jySPC;
                    ccdData.Save(saveFileName);
                }
                else
                {
                    ccdData.FileType = JYSYSTEMLIBLib.jySupportedFileType.jyTabDelimitted;
                    ccdData.Save(saveFileName);
                }
            }
            catch
            {
                Console.WriteLine("Couldn't open data file, make sure folder exists");
                return;
            }
            */
        }

        public Object Acquire_data(bool state)
        {
            IJYResultsObject result;
            Object Array;

            mCCD.StartAcquisition(state);
            int i = 0;
            while(i<100 && mCCD.AcquisitionBusy())
            {
                System.Threading.Thread.Sleep(1);
                i++;
            }
            result = mCCD.GetResult();
            result.GetFirstDataObject().GetDataAsArray(out Array);

            return Array;
        }


        // Synchronus data acquisition
        public void GetData(double ScanStart, double ScanEnd, double ScanInc = 0.036)
        {
            Double dPos, dValue;
            String sMsg, sPos, sDisplay;
            Boolean isMonoBusy, isCCDBusy;
            System.Object oData = null;
            bool m_bSyncAcq, m_bStopAcq;
            int m_loopCount;
            DataRow row;

            if (mCCD == null)
            {
                Console.WriteLine("Monochromator Must Be Selected and Initialized Before Collecting Data");
                return;
            }

            if ((ScanStart < 0) || (ScanEnd <= 0) || (ScanInc <= 0))
            {
                sMsg = String.Format("Invalid Scan Start ({0}), Stop ({1}) or Inc ({2}) Value", ScanStart, ScanEnd, ScanInc);
                Console.WriteLine(sMsg);
                return;
            }
            else if (ScanStart > ScanEnd)
            {
                Console.WriteLine("Scan End Must Be Greater Than Scan Start.");
                return;
            }
            Object positions = new Object();
            int numCovers = 0;
            mCCD.CalculateRangeModePositions(ScanStart, ScanEnd, 2, out numCovers, out positions);

            m_bSyncAcq = true;
            m_bStopAcq = false;

            // A Synchronous (or Serial) acquisition method will loop through the positions requested, moving 
            // the mono and taking data at every point.  NOTE: this method will not relinquish control to the 
            // UI thread (i.e. - the UI will appear hung) until it has completed.  If this operation is 
            // already taking place on a non-ui thread, then this is not an issue.  If your scan is happening 
            // in the main UI thread, then you'd want to consider using the Asynchronous method of acquisition...
            dPos = ScanStart;
            dData.Clear();
            myFunc.add_to_log("GetData()", "Loop Started");
            while (dPos <= ScanEnd)
            {
                // move mono
                mMono.MovetoWavelength(dPos);

                isMonoBusy = true;
                while (isMonoBusy == true)
                {
                    isMonoBusy = mMono.IsBusy();
                }
                dPos = mMono.GetCurrentWavelength();
                myFunc.add_to_log("GetData()", dPos.ToString());
                // Start the acquisition
                isCCDBusy = true;
                mCCD.StartAcquisition(true);
                while ((isCCDBusy == true) && (m_bStopAcq == false))
                {
                    // Poll Busy
                    isCCDBusy = mCCD.AcquisitionBusy();
                }

                // Retrieve the data
                mCCD.GetData(ref oData);

                IConvertible convert = oData as IConvertible;
                if (convert != null)
                    dValue = convert.ToDouble(null);
                else
                    dValue = 0d;

                row = dData.NewRow();

                row["Wavelength"] = dPos;
                row["Intensity"] = dValue;
                dData.Rows.Add(row);

                if (m_bStopAcq == true)
                    break;

                dPos += ScanInc;

            }          // end of loop



        }



        public void GetPosition()
        {
            Double dCurrPosition = 0;
            dCurrPosition = mMono.GetCurrentWavelength();
            Text_CurrentWavelength = dCurrPosition.ToString("0.00");
            mbPositionChanged = false;
        }

        public void GetMirrors()
        {
            MirrorLocation locationEN, locationEX;
            Boolean bIsInstalled = true, bEnt = false, bExit = false;

            //Entrance mirror
            bIsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Mirror_Entrance);
            if (bIsInstalled)
            {
                bEnt = true;

                locationEN = mMono.GetCurrentMirrorPosition(MirrorLocation.EntranceMirror);
                switch (locationEN)
                {
                    case MirrorLocation.Front:
                        Radio_Entrance_Axial = true;
                        break;

                    case MirrorLocation.Side:
                        Radio_Entrance_Lateral = true;
                        break;

                    default:
                        break;
                }
            }

            //Exit mirror
            bIsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Mirror_Exit);
            if (bIsInstalled)
            {
                bExit = true;

                locationEX = mMono.GetCurrentMirrorPosition(MirrorLocation.ExitMirror);
                switch (locationEX)
                {
                    case MirrorLocation.Front:
                        Radio_Exit_Axial = true;
                        break;

                    case MirrorLocation.Side:
                        Radio_Exit_Lateral = true;
                        break;

                    default:
                        break;
                }
            }

        }

        public void GetGratings()
        {
            int nCurrTurr;
            Double dCurrTurr;
            Object oGratings;
            Array arrGratings;

            combobox_Grating.Clear();

            nCurrTurr = mMono.GetCurrentTurret();

            mMono.GetCurrentGrating(out dCurrTurr, out oGratings);

            try
            {
                arrGratings = (Array)oGratings;
                foreach (double grating in arrGratings)
                {
                    combobox_Grating.Add(grating);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetSlits()
        {
            //get slit width from the component
            // Check to see if slit of each type is installed
            bool IsInstalled = true, bEitherEnt = false, bEitherExit = false;
            double slitWidthFE = 0, slitWidthFX = 0, slitWidthSE = 0, slitWidthSX = 0;

            //Front_Entrance slit
            IsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Slit_Front_Entrance);
            if (IsInstalled)
            {
                slitWidthFE = mMono.GetCurrentSlitWidth(SlitLocation.Front_Entrance);
                Text_Slit_Front_Entrance = Convert.ToString(slitWidthFE);
                bEitherEnt = true;
            }
            else
            {
                Text_Slit_Front_Entrance = "";
            }

            //Front_Exit slit
            IsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Slit_Front_Exit);
            if (IsInstalled)
            {
                slitWidthFX = mMono.GetCurrentSlitWidth(SlitLocation.Front_Exit);
                Text_Slit_Front_Exit = Convert.ToString(slitWidthFX);
                bEitherEnt = true;
            }
            else
            {
                Text_Slit_Front_Exit = "";
            }

            //Side_Entrance slit
            IsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Slit_Side_Entrance);
            if (IsInstalled)
            {
                slitWidthSE = mMono.GetCurrentSlitWidth(SlitLocation.Side_Entrance);
                Text_Slit_Side_Entrance = Convert.ToString(slitWidthSE);
                bEitherExit = true;
            }
            else
            {
                Text_Slit_Side_Entrance = "";
            }

            //Side_Exit slit
            IsInstalled = mMono.IsSubItemInstalled(MonoSubItemType.Slit_Side_Exit);
            if (IsInstalled)
            {
                slitWidthSX = mMono.GetCurrentSlitWidth(SlitLocation.Side_Exit);
                Text_Slit_Side_Exit = Convert.ToString(slitWidthSX);
                bEitherExit = true;
            }
            else
            {
                Text_Slit_Side_Exit = "";
            }

        }

        public void MoveToTurret(int nSelectedTurr)
        {
            mMono.MovetoTurret(nSelectedTurr);
        }

        public void SetParameters(ADCStringType ADC, PairStringInt Gain, bool image_format = false)
        {
            mCCD.SelectADC(ADC.adcType);
            mCCD.Gain = Gain.iVal;

            int XStart = 1; int YStart = 1; int XEnd = 1024; int YEnd = 256; int XBin = 1;
            int YBin = 256;

            // Define format: m=0: Spectra mode
            jyCCDDataType mode;
            mode = jyCCDDataType.JYMCD_ACQ_FORMAT_SCAN; // Spectra
            if (image_format)
            {
                mode = jyCCDDataType.JYMCD_ACQ_FORMAT_IMAGE;
                YBin = 1;
            }
            mCCD.DefineAcquisitionFormat(mode, 1);
            mCCD.DefineArea(1, XStart, YStart, XEnd - XStart + 1, YEnd - YStart + 1, XBin, YBin);
            mCCD.DisableAllInputTriggers();
            mCCD.SetOperatingModeValue(0, false);
            mCCD.AcquisitionCount = 1;
        }

        public bool ReadForAcq()
        {
            return mCCD.ReadyForAcquisition;
        }


        private List<ADCStringType> InitializeADCSelect()
        {
            int token, lastToken;
            String sName;
            int currentADC;
            ADCStringType ADC;
            List<ADCStringType> temp = new List<ADCStringType>();

            // Get the currently selected ADC so we can select it programmatically when we come
            // across it in the enumeration
            currentADC = mCCD.CurrentADC;
            token = mCCD.GetFirstADC(out sName);
            //myFunc.add_to_log("InitializeADCSelect", sName);
            myFunc.add_to_log("InitializeADCSelect", token.ToString());
            if (token == -1)
            {
                ADC = new ADCStringType();
                ADC.sVal = "NONE";
                ADC.adcType = (jyADCType)token;
                temp.Add(ADC);
            }
            else
            {
                while (token != -1)
                {
                    ADC = new ADCStringType();
                    ADC.sVal = sName;
                    ADC.adcType = (jyADCType)token;
                    //myFunc.add_to_log("InitializeADCSelect", sName);
                    temp.Add(ADC);
                    token = mCCD.GetNextADC(out sName);
                }
            }
            return temp;

        }
        private List<PairStringInt> InitializeGainSelect()
        {
            int token;
            String sName;
            int lastGain;
            PairStringInt Gain;

            lastGain = mCCD.Gain;
            List<PairStringInt> temp = new List<PairStringInt>();

            token = mCCD.GetFirstGain(out sName);
            //myFunc.add_to_log("InitializeGainSelect", sName);
            myFunc.add_to_log("InitializeGainSelect", token.ToString());
            if (token == -1)
            {
                Gain = new PairStringInt();
                Gain.sVal = "NONE";
                Gain.iVal = token;
                temp.Add(Gain);
            }
            else
            {
                while (token != -1)
                {
                    Gain = new PairStringInt();
                    Gain.sVal = sName;
                    Gain.iVal = token;
                    //myFunc.add_to_log("InitializeGainSelect", sName);
                    temp.Add(Gain);
                    token = mCCD.GetNextGain(out sName);
                }
            }
            return temp;
        }

        /// <summary>
        /// Return true if width moved correctly
        /// </summary>
        /// <param name="slitloc">0: Front Entrance, 1: Side Entrance, 2: Front Exit,
        /// 3: Side Exit, 4: First Intermediate, 5: Second Intermediate</param>
        /// <param name="width"></param>
        public bool SetWidth(int slitloc,  double width)
        {
            if(width < 0 || width > 2.2) { return false; }
            if(slitloc == 0)
            {
                mMono.MovetoSlitWidth(SlitLocation.Front_Entrance, width);
            }
            else if(slitloc == 1) 
            {
                mMono.MovetoSlitWidth(SlitLocation.Side_Entrance, width);
            }
            else if (slitloc == 2)
            {
                mMono.MovetoSlitWidth(SlitLocation.Front_Exit, width);
            }
            else if (slitloc == 3)
            {
                mMono.MovetoSlitWidth(SlitLocation.Side_Exit, width);
            }
            else if (slitloc == 4)
            {
                mMono.MovetoSlitWidth(SlitLocation.First_Intermediate, width);
            }
            else if (slitloc == 5)
            {
                mMono.MovetoSlitWidth(SlitLocation.Second_Intermediate, width);
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Moves to Mirror Position
        /// </summary>
        /// <param name="entrance"> true: entrance, false: exit</param>
        /// <param name="front"> true: front, false: side</param>
        public void SetMirror(bool entrance, bool front)
        {
            if(entrance && front)
            {
                mMono.MovetoMirrorPosition(MirrorLocation.EntranceMirror, MirrorLocation.Front);
            }
            else if(entrance && !front)
            {
                mMono.MovetoMirrorPosition(MirrorLocation.EntranceMirror, MirrorLocation.Side);
            }
            else if (!entrance && front)
            {
                mMono.MovetoMirrorPosition(MirrorLocation.ExitMirror, MirrorLocation.Front);
            }
            else if (!entrance && !front)
            {
                mMono.MovetoMirrorPosition(MirrorLocation.ExitMirror, MirrorLocation.Side);
            }

            
        }


        //=============================================
        public void Test_GetData(double ScanStart, double ScanEnd, double ScanInc = 1)
        {
            Double dPos, dValue;
            String sMsg, sPos, sDisplay;
            Boolean isMonoBusy, isCCDBusy;
            System.Object oData = null;
            int m_loopCount;
            DataRow row;

            double[] wavelength_array = { };
            double[] intensities_array = { };

            myFunc.add_to_log("Test", "Calibration coefficients " + (mCCD.GetFirstCalibrationCoefficient()).ToString());
            myFunc.add_to_log("Test", "Next Calibration coefficients " + (mCCD.GetNextCalibrationCoefficient()).ToString());
            myFunc.add_to_log("Test", "Next Calibration coefficients " + (mCCD.GetNextCalibrationCoefficient()).ToString());

            SetWidth(0, 1);

            //JYSYSTEMLIBLib.IJYResultsObject ccdResult = mCCD.GetResult();

            myFunc.add_to_log("Test", "Initial AcqShutterMode " + mCCD.MultiAcqShutterMode.ToString());
            mCCD.MultiAcqShutterMode = jyMultiAcqState.jyMultiAcqStateBeforeFirstOnly;
            myFunc.add_to_log("Test", "New AcqShutterMode " + mCCD.MultiAcqShutterMode.ToString());

            int ac = mCCD.AcquisitionCount;
            myFunc.add_to_log("Test", "Acquisiton Count " + ac.ToString());

            Int32 numCov;
            Object positions = new Object();

            Object param;
            //double[] param = { 0.033, 649.7961 };
            //mCCD.SetLinearizationParams(param);
            //myFunc.add_to_log("Test", "Linearization param set");
            mCCD.GetLinearizationParams(out param);
            myFunc.add_to_log("Test", "Linearization param set");
            myFunc.add_to_log("Test", "Linearization param set: " + string.Join(",", ((Array)param)));
            myFunc.add_to_log("Test", "Linearization param set: " + string.Join(",", ((Array)param).GetLength(0)));
            mCCD.CalculateRangeModePositions(ScanStart, ScanEnd, 1, out numCov, out positions);
            
            myFunc.add_to_log("Test", "Number Covers " + numCov.ToString());
            //myFunc.add_to_log("Test", "Positions " + positions.ToString());
            myFunc.add_to_log("Test", "Positions " + string.Join(",", ((Array)positions)));
            
            double[] pos_array = { (ScanEnd + ScanStart) / 2 };
                //(double[])positions;

            //JYSYSTEMLIBLib.IJYDataObject ccdData = ccdResult.GetFirstDataObject();

            if (mCCD == null || mMono == null)
            {
                Console.WriteLine("Monochromator Must Be Selected and Initialized Before Collecting Data");
                return;
            }

            //mCCD.IntegrationTime = mCCD.IntegrationTime * (ScanEnd - ScanStart) / (ScanInc * 1000);

            dPos = ScanStart;
            dData.Clear();
            myFunc.add_to_log("GetData()", "Loop Started");
            mMono.MovetoWavelength(dPos);
            //mCCD.StartAcquisition(true); // Open shutter once
            for(int i = 0; i < 1; i++) 
            {
                // move mono
                myFunc.add_to_log("Test", "Move to wavelength " + (pos_array[i].ToString()));
                mMono.MovetoWavelength(pos_array[i]);

                isMonoBusy = true;
                while (isMonoBusy == true)
                {
                    isMonoBusy = mMono.IsBusy();
                }
                dPos = mMono.GetCurrentWavelength();
                myFunc.add_to_log("GetData()", dPos.ToString());
                // Start the acquisition
                mCCD.StartAcquisition(true);
                // Retrieve the data
                ccdResult = mCCD.GetResult();
                ccdData = ccdResult.GetFirstDataObject();
                Object temp;
                ccdData.GetDataAsArray(out temp);

                /*
                IConvertible convert = ccdData as IConvertible;
                if (convert != null)
                    dValue = convert.ToDouble(null);
                else
                    dValue = 0d;
                */
                foreach(var a in (Array)temp)
                {
                    intensities_array.Append<double>((double)a);
                }

                /*
                row = dData.NewRow();

                row["Wavelength"] = dPos;
                row["Intensity"] = dValue;
                dData.Rows.Add(row);
                */

            }          // end of loop


        }
        
        
        
        public void OnCCDEvent_Update(int updateType, JYSYSTEMLIBLib.IJYEventInfo eventInfo)
        {
            string msg;
            Object dataArray;

            // Update type 100 indicates that this is a data update. Currently the 
            // only type of update event fired by the ccd object
            if (updateType != 100)
                return;

            // JYSYSTEMLIBLib.IJYResultsObject ccdResult = eventInfo.GetResult();
            // JYSYSTEMLIBLib.IJYDataObject ccdData = ccdResult.GetFirstDataObject();
            try
            {
                ccdResult = eventInfo.GetResult();
            }
            catch (Exception ex)
            {
                string sErr = string.Copy("Failed During Acquistion: Get Result Obj Failed");
                msg = string.Format("{0}\r\n{1}", sErr, ex.Message);
                MessageBox.Show(msg, "Acquistion Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Process the data. The following simply retrieves the dataObject 
                // from the result that carries it. This data object will be used in 
                // the event an attempt is made to save the data.
                ccdData = ccdResult.GetFirstDataObject();
                if (ccdData == null)
                {
                    string sErr = string.Copy("GetFirstDataObject() Failed: Did notGet Data Object");
                    MessageBox.Show(sErr, "Failed To Get Data Object", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ccdData.GetDataAsArray(out dataArray, true, 1);
                int yyy = 0;

                int numDims = ccdData.NumberOfDimensions;
                int xdim = ccdData.GetDimension(1);
                int ydim = 1;
                if (numDims > 1)
                {
                    ydim = ccdData.GetDimension(2);
                }

                if (JYSYSTEMLIBLib.jyDataObjectDataFormat.jyDFInt32 == ccdData.DataFormat)
                {
                    // 3 ways (at least) to get the data collected.
                    Int32 firstpt, lastpt;
                    Array aa;

                    if (ydim > 1)
                    {
                        // 1st way is to pull each value out using GetValue (slowest way)
                        aa = (Array)dataArray;
                        firstpt = (Int32)aa.GetValue(0, 0);
                        lastpt = (Int32)aa.GetValue(xdim - 1, ydim - 1);

                        // 2nd way is to copy two-dimensional array
                        Int32[,] I_arrptr = new Int32[xdim, ydim];
                        // copy aa array starting at first element to arrptr array starting at it's first element. copy Length elements
                        Array.Copy(aa, 0, I_arrptr, 0, aa.Length);
                        firstpt = I_arrptr[0, 0];
                        lastpt = I_arrptr[xdim - 1, ydim - 1];

                        // 3rd way is to copy array as block copy (fastest way)
                        Int32[,] I_arrptr2 = new Int32[xdim, ydim];
                        // copy Length * size of data type bytes to array 
                        Buffer.BlockCopy(aa, 0, I_arrptr2, 0, aa.Length * sizeof(Int32));
                        firstpt = I_arrptr2[0, 0];
                        lastpt = I_arrptr2[xdim - 1, ydim - 1];
                    }
                    else
                    {
                        // 1st way is to pull each value out using GetValue (slowest way)
                        aa = (Array)dataArray;
                        firstpt = (Int32)aa.GetValue(0);
                        lastpt = (Int32)aa.GetValue(xdim - 1);

                        // 2nd way is to copy two-dimensional array
                        Int32[] S_arrptr = new Int32[xdim];
                        // copy aa array starting at first element to arrptr array starting at it's first element. copy Length elements
                        Array.Copy(aa, 0, S_arrptr, 0, aa.Length);
                        firstpt = S_arrptr[0];
                        lastpt = S_arrptr[xdim - 1];

                        // 3rd way is to copy array as block copy (fastest way)
                        Int32[] S_arrptr2 = new Int32[xdim];
                        // copy Length * size of data type bytes to array 
                        Buffer.BlockCopy(aa, 0, S_arrptr2, 0, aa.Length * sizeof(Int32));
                        firstpt = S_arrptr2[0];
                        lastpt = S_arrptr2[xdim - 1];
                    }
                }

                // Do something with data array...

            }
            catch (Exception ex)
            {
                string sErr = string.Copy("Failed During Acquistion: Get Data Obj Failed");
                msg = string.Format("{0}\r\n{1}", sErr, ex.Message);
                MessageBox.Show(msg, "Acquistion Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Make Sure To Click 'Set Params' Button After Changing Any Items In Setup", "Acquistion Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}