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

namespace MPhys.GUI
{
    public partial class PMForm : Form
    {
        PM100A PMdev;
        public bool is_open;
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

            try
            {
                PMdev = new PM100A();
                textBoxPower.Text = PMdev.Get_power().ToString();
                textPMconnection.BackColor = Color.Green;
            }
            catch
            {
                textPMconnection.BackColor = Color.Red;
            }


        }

        private void modify_com_boxes()
        {
            string PMport = ConfigurationManager.AppSettings.Get("PM100A");
            textPMconnection.Text = PMport;

            check_com(PMport);

        }

        private void check_com(string com1)
        {
            // PM100
            try
            {
                PMdev = new PM100A();
                textBoxPower.Text = PMdev.Get_power().ToString();
                textPMconnection.BackColor = Color.Green;
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
    }
}
