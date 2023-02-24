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
        private JYMONOLib.MonochromatorClass mMono;

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

        private void Initialize(String CurrMono)
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
                mMono._IJYDeviceReqdEvents_Event_Initialize += OnReceivedInitMono;

                // Loads up the device with the specified configuration
                mMono.Load();

                tbStatus.Clear();
                sStatus = String.Format("Opening Communications ... ");
                tbStatus.AppendText(sStatus);

                // Attempts to communicate with a device on the specified communication 
                // settings (in the configuration). If it fails, the catch allows the
                // device to be emulated in software.
                mMono.OpenCommunications();

                // OpenCommunications() succeeded - no need to Emulate
                mbEmulate = false;

                sStatus = String.Format("Complete{0}", Environment.NewLine);
                tbStatus.AppendText(sStatus);

            }
            catch (Exception ex)
            {
                sStatus = String.Format("Failed{0}", Environment.NewLine);
                tbStatus.AppendText(sStatus);

                DialogResult dr;
                sStatus = String.Format(
                    "{0} Hardware Not Detected{1}{1}Do you want to emulate this device?",
                    sMonoName, Environment.NewLine);
                dr = MessageBox.Show(
                    sStatus, "Mono Hardware Not Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    // Yes: Emulate
                    mbEmulate = true;
                    sStatus = String.Format("Emulating {0} ...{1}", sMonoName, Environment.NewLine);
                    tbStatus.AppendText(sStatus);
                }
                else if (dr == DialogResult.No)
                {
                    // No: Do not Emulate
                    mbEmulate = false;
                    sStatus = String.Format("Check {0} Hardware and attempt again.", sMonoName);
                    tbStatus.AppendText(sStatus);
                    return;
                }
            }


            // INITIALIZE
            try
            {
                // Disable Intialize button while Initializing - could take time
                buttonInitialize.Enabled = false;
                labelInitStatus.Text = "Initializing...";
                labelInitStatus.ForeColor = Color.Black;

                sStatus = String.Format("Initializing Mono ... ");
                tbStatus.AppendText(sStatus);

                if (mbInitialized == true)
                    mbForceInit = true;

                mMono.Initialize(mbForceInit, mbEmulate, false);
            }
            catch (Exception ex)
            {
                sStatus = String.Format("{0} Initialize Failed.{1}", sMonoName, Environment.NewLine);
                MessageBox.Show(sStatus, "Mono Initialize", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Disable Intialize button while Initializing - could take time
                buttonInitialize.Enabled = true;
                buttonInitialize.Text = "Initialize";
                labelInitStatus.Text = "Error";
                labelInitStatus.ForeColor = Color.Red;
            }
        }
    }
}
