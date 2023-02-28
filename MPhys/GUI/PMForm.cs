using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MPhys.Devices;
using System.Configuration;
using System.Diagnostics;
using System.Timers;

namespace MPhys.GUI
{
    public partial class PMForm : Form
    {
        PM100A PMdev;
        public bool DevOpen = false;

        public PMForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;


            string PMport = ConfigurationManager.AppSettings.Get("PM100A");
            textPMconnection.Text = PMport;
            textBoxConnSet.Text = PMport;

            modify_com_boxes();

            timer1.Start();

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
                if(PMdev != null)
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
            string new_com = textBoxConnSet.Text.ToString();
            textPMconnection.Text = new_com;

            UpdateAppSettings("PM100A", new_com);
            modify_com_boxes();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PMdev != null && DevOpen)
            {
                textBoxPower.Text = PMdev.Get_power().ToString();
                textCorr.Enabled = true;
                buttonSetCorr.Enabled = true;
            }
            if (PMdev == null)
            {
                //textCorr.Enabled = false;
                //buttonSetCorr.Enabled = false;
                modify_com_boxes();
            }
            check_com();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxConnSet.Enabled = true;
                buttonComSet.Enabled = true;
            }
            else
            {
                textBoxConnSet.Enabled = false;
                buttonComSet.Enabled = false;
            }
        }

        private void buttonSetCorr_Click(object sender, EventArgs e)
        {
            string a = textCorr.Text.ToString();
            try
            {
                double wavelength = double.Parse(textCorr.Text.ToString());
                if(wavelength > 0 && wavelength < 1000)
                {
                    PMdev.Change_wavelength_correction(wavelength);
                }
                else
                {
                    MessageBox.Show("Must be a number within 0nm, 1000nm");
                }
            }
            catch
            {
                MessageBox.Show("Must be a number");
            }
        }
    }
}
