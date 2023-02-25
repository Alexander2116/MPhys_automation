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



        private void modify_com_boxes()
        {
            string PMport = ConfigurationManager.AppSettings.Get("PM100A");
            textPMconnection.Text = PMport;
            try
            {
                PMdev = new PM100A(PMport);
                PMdev.Get_power();
                DevOpen = true;
            }
            catch { }

            check_com();

        }

        private void check_com()
        {
            // PM100
            try
            {
                if (PMdev != null)
                {
                    textBoxPower.Text = PMdev.Get_power().ToString();
                    textPMconnection.BackColor = Color.Green;
                }
                else
                {
                    textPMconnection.BackColor = Color.Red;
                }
            }
            catch
            {
                textPMconnection.BackColor = Color.Red;
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

            if(comboBoxSCDs.Enabled == true)
            {

            }

            SCD.sID = sID;
            SCD.sName = sName;

            if (sName != "")
            {
                MonoSpec.Initialize(SCD);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBoxSCDs.Enabled = true;
            }
            else
            {
                comboBoxSCDs.Enabled = false;
            }
        }
    }
}
