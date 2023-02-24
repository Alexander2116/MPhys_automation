/*============================================================
**
** Class:  HR550
**
** Purpose: Connect to Horiba iHR550 spectrometer
**        : Control the spectrometer (inc. shutter)
**
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
        public List<SCDid> combobox_list = new List<SCDid>(); // Upload list to ComboBox in the form

        // Initilize, adding all available objects to combobox_list (all available SCDs)
        HR550()
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

        private void Initialize(SCDid CurrMono)
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

                Application.DoEvents();


                mMono.GetDefaultUnits(jyUnitsType.jyutSlitWidth, out Units, out oUnitsString);
            }
            else
            {
                sStatus = String.Format("Failed{0}", Environment.NewLine);
                Console.WriteLine(sStatus);
            }
        }
    }
}
