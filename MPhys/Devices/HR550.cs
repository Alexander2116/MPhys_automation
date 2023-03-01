/*============================================================
**
** Class:  HR550
**
** Purpose: Connect to Horiba iHR550 spectrometer
**        : Control the spectrometer (inc. shutter)
**
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

using JYMONOLib;
using JYCONFIGBROWSERCOMPONENTLib;
using JYSYSTEMLIBLib;
using JYCCDLib;
using JYSCDLib;

namespace MPhys.Devices
{
    public class SCDid
    {
        public string sName;
        public string sID;
        public override string ToString()
        {
            return sName.ToString();
        }
    }

    class HR550
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

        // Should be private, may change it later
        public JYConfigBrowerInterface mConfigBrowser;
        public JYMONOLib.MonochromatorClass mMono;

        // CCD
        //public JYCCDLib.JYMCDClass mCCD;
        public JYSYSTEMLIBLib.IJYDataObject ccdData;
        public JYSYSTEMLIBLib.IJYResultsObject ccdResult;
        public JYSCDLib.JYSCDClass mCCD;

        // jyCCD = new JYCCDLib.JYMCDClass();
        // jyMono = new JYMONOLib.MonochromatorClass();

        String sDevId;
        String sDevName;
        String SCD; // SCDid

        // Lists for ComboBoxes
        public List<SCDid> combobox_Mono = new List<SCDid>(); // Upload list to ComboBox in the form
        public List<SCDid> combobox_CCD = new List<SCDid>(); // Upload list to ComboBox in the form
        public List<double> combobox_Grating = new List<double>(); // List of gratings

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

        // Initilize, adding all available objects to combobox_list (all available SCDs)
        public HR550()
        {
            String sDevId;
            String sDevName;
            SCDid SCD;

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

                sDevId = mConfigBrowser.GetFirstSCD(out sDevName);
                while ((sDevName != null) && (String.Compare(sDevName, "") != 0))
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

        public bool can_be_initialized()
        {
            try
            {
                
                mMono = new JYMONOLib.MonochromatorClass();
                mMono = null;
                mCCD = new JYSCDLib.JYSCDClass();
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
            String sDevUniqueId;
            String sDevFoundName;
            String sStatus;

            // OPEN COMMUNICATIONS
            try
            {
                // Find Selected Device UniqueId & Name
                sMonoDevId = CurrMono.sID;

                if ((sMonoDevId == null) || (sMonoDevId.CompareTo("") == 0))
                    return;

                sDevUniqueId = mConfigBrowser.GetFirstMono(out sDevFoundName);

                while ((sDevUniqueId != null) && (sDevUniqueId.CompareTo(sMonoDevId) != 0))
                {
                    sDevUniqueId = mConfigBrowser.GetNextMono(out sDevFoundName);
                }

                sMonoName = sDevFoundName;

                // Create New MonochromatorClass
                mMono = new JYMONOLib.MonochromatorClass();

                mMono.Uniqueid = sDevUniqueId;

                // Set Mono Initialize event handler
                // NO

                // Loads up the device with the specified configuration
                mMono.Load();

                sStatus = String.Format("Opening Communications ... ");
                Console.WriteLine(sStatus);
                // Attempts to communicate with a device on the specified communication 
                // settings (in the configuration). If it fails, the catch allows the
                // device to be emulated in software.
                mMono.OpenCommunications();


                sStatus = String.Format("Complete{0}", Environment.NewLine);
                Console.WriteLine(sStatus);

            }
            catch (Exception ex)
            {
                sStatus = String.Format("Failed{0}", Environment.NewLine);
                Console.WriteLine(sStatus);
            }


            // INITIALIZE
            try
            {
                sStatus = String.Format("Initializing Mono ... ");
                Console.WriteLine(sStatus);

                if (mbInitialized == true)
                    mbForceInit = true;

                mMono.Initialize(mbForceInit, mbEmulate, false);
            }
            catch (Exception ex)
            {
                sStatus = String.Format("{0} Initialize Failed.{1}", sMonoName, Environment.NewLine);
                Console.WriteLine(sStatus);
            }
        }

        public void InitializeCCD(SCDid CurrCCD)
        {
            String sDevUniqueId = CurrCCD.sID;
            String sDevFoundName = CurrCCD.sName;
            String sStatus;

            // OPEN COMMUNICATIONS
            try
            {
                // Find Selected Device UniqueId & Name
                /*
                sCCDId = CurrCCD.sID;

                if ((sCCDId == null) || (sCCDId.CompareTo("") == 0))
                    return;

                sDevUniqueId = mConfigBrowser.GetFirstCCD(out sDevFoundName);
                int temp_i = 0;
                while (((sDevUniqueId != null) && (sDevUniqueId.CompareTo(sMonoDevId) != 0)) && temp_i < 10)
                {
                    sStatus = String.Format("Loop ... ");
                    Console.WriteLine(sStatus);
                    sDevUniqueId = mConfigBrowser.GetNextCCD(out sDevFoundName);
                    temp_i += 1;
                }
                */

                sMonoName = sDevFoundName;

                // Create New MonochromatorClass
                mCCD = new JYSCDLib.JYSCDClass();

                mCCD.Uniqueid = sDevUniqueId;

                // Set Mono Initialize event handler
                // NO

                // Loads up the device with the specified configuration
                mCCD.Load();

                sStatus = String.Format("Opening Communications ... ");
                Console.WriteLine(sStatus);
                // Attempts to communicate with a device on the specified communication 
                // settings (in the configuration). If it fails, the catch allows the
                // device to be emulated in software.
                mCCD.OpenCommunications();


                sStatus = String.Format("Complete{0}", Environment.NewLine);
                Console.WriteLine(sStatus);

            }
            catch (Exception ex)
            {
                sStatus = String.Format("Failed{0}", Environment.NewLine);
                Console.WriteLine(sStatus);
            }


            // INITIALIZE
            try
            {
                sStatus = String.Format("Initializing Mono ... ");
                Console.WriteLine(sStatus);

                if (mbInitialized == true)
                    mbForceInit = true;

                mMono.Initialize(mbForceInit, false, false);
            }
            catch (Exception ex)
            {
                sStatus = String.Format("{0} Initialize Failed.{1}", sMonoName, Environment.NewLine);
                Console.WriteLine(sStatus);
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

        public bool IsBusy()
        {
            return mMono.IsBusy();
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

            counter = 1;

            JYSYSTEMLIBLib.IJYDataObject[] dataarray;
            dataarray = new JYSYSTEMLIBLib.IJYDataObject[total_count];

            do
            {

                // Start data Acquisition
                mCCD.StartAcquisition(true);
                // wait for data to come in (busy = False)
                do
                    busy = mCCD.AcquisitionBusy();
                while (busy == true);

                // Get result of data acquisition
                //ccdResult = mCCD.GetResult();
                mCCD.GetData(ccdResult);
                // pull off as data object
                ccdData = ccdResult.GetFirstDataObject();

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
                        ccdData.Save(fname);
                    }
                    catch
                    {
                        Console.WriteLine("Couldn't open data file, make sure folder exists", "Error");
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

        public void Start_acquisition()
        {
            mCCD.DoAcquisition(true);
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
                        Radio_Exit_Lateral= true;
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

    }
}
