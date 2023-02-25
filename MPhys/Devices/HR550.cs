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

using JYMONOLib;
using JYCONFIGBROWSERCOMPONENTLib;
using JYSYSTEMLIBLib;

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

        public JYConfigBrowerInterface mConfigBrowser;
        private JYMONOLib.Monochromator mMono; // ??? Why ??? It works in the different example

        String sDevId;
        String sDevName;
        String SCD; // SCDid

        // Lists for ComboBoxes
        public List<SCDid> combobox_list = new List<SCDid>(); // Upload list to ComboBox in the form
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
                    combobox_list.Add(SCD);

                    // Find the next Mono in this Configuration
                    sDevId = mConfigBrowser.GetNextMono(out sDevName);
                }


            }
            catch (SystemException ex)
            {
                // Received Exception: report & exit
                Console.WriteLine(String.Format("Exception: {0}", ex.Message));
                return;
            }
        }

        public void Initialize(SCDid CurrMono)
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
                mMono = new JYMONOLib.Monochromator();

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

                // OpenCommunications() succeeded - no need to Emulate
                mbEmulate = false;

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







        private void GetPosition()
        {
            Double dCurrPosition = 0;
            dCurrPosition = mMono.GetCurrentWavelength();
            Text_CurrentWavelength = dCurrPosition.ToString("0.00");
            mbPositionChanged = false;
        }

        void GetMirrors()
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

        private void GetGratings()
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


        private void GetSlits()
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
