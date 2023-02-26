using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPhys.Devices;
using System.Configuration;
using System.Diagnostics;
using System.Timers;

namespace MPhys.GUI
{

    public partial class SpecForm : Form
    {
        HR550 MonoSpec;

        public SpecForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            try
            {
                MonoSpec = new HR550();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        // Function to activate all buttons
        private void Activate_buttons()
        {
            if(StatusLabel.ForeColor == Color.Green && button_shutter.Enabled == false)
            {
                button_shutter.Enabled = true;
                groupboxWlCtrl.Enabled = true;
            }
            else
            {
                button_shutter.Enabled = false;
                groupboxWlCtrl.Enabled = false;
            }
        }

        private void Is_initialized()
        {
            if (MonoSpec.mMono != null && StatusLabel.Text != "Connected")
            {
                StatusLabel.Text = "Connected";
                StatusLabel.ForeColor = Color.Green;
            }
            else
            {
                StatusLabel.Text = "Disconnected";
                StatusLabel.ForeColor = Color.Red;
            }

        }

        static void UpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void buttonComSet_Click(object sender, EventArgs e)
        {
            SCDid SCD = new SCDid();
            string sName = ConfigurationManager.AppSettings.Get("iHR550_sName");
            string sID = ConfigurationManager.AppSettings.Get("iHR550_sID");

            if(comboBoxSCDs.Enabled == true && comboBoxSCDs.Text != null && comboBoxSCDs.Text != "")
            {
                SCD = (SCDid)comboBoxSCDs.SelectedItem;
                UpdateAppSettings("iHR550_sName", SCD.sName);
                UpdateAppSettings("iHR550_sID", SCD.sID);
            }

            SCD.sID = sID;
            SCD.sName = sName;

            if (sName != "")
            {
                try
                {
                    MonoSpec.InitializeMono(SCD);
                    StatusLabel.Text = "Connected";
                    StatusLabel.ForeColor = Color.Green;
                    textboxPosition.Text = MonoSpec.Text_CurrentWavelength;
                }
                catch
                {
                    StatusLabel.Text = "Disconnected";
                    StatusLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                StatusLabel.Text = "Disconnected";
                StatusLabel.ForeColor = Color.Red;
            }

            Activate_buttons();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBoxSCDs.Enabled = true;
                foreach(SCDid s in MonoSpec.combobox_Mono)
                {
                    comboBoxSCDs.Items.Add(s);
                }
            }
            else
            {
                comboBoxSCDs.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(comboBoxSCDs.Items.Count < 1 && checkBox1.Checked)
            {
                MonoSpec = new HR550();
                foreach (SCDid s in MonoSpec.combobox_Mono)
                {
                    comboBoxSCDs.Items.Add(s);
                }
            }
        }

        private void button_shutter_Click(object sender, EventArgs e)
        {
            string ltext = ShutterStateLabel.Text;
            if(ltext =="Open")
            {
                MonoSpec.Close_Shutter();
                ShutterStateLabel.Text = "Close";
            }
            else
            {
                MonoSpec.Open_Shutter();
                ShutterStateLabel.Text = "Open";
            }
        }

        private void comboboxGrating_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bBusy;

            try
            {
                bBusy = true;
                while (bBusy == true)
                {
                    Application.DoEvents();
                    bBusy = MonoSpec.IsBusy();
                }
                MonoSpec.GetPosition();
                textboxPosition.Text = MonoSpec.Text_CurrentWavelength;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
