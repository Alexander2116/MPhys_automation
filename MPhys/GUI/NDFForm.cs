using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MPhys.Devices;
using System.IO.Ports;

namespace MPhys.GUI
{
    public partial class NDFForm : Form
    {
        private FC102C NDF1;
        private FC102C NDF2;

        public NDFForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            modify_com_boxes();

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
                comboBox2.Items.Add(s);
            }
        }

        #region Private functions 
        private void check_com(string com1, string com2)
        {
            // NDF1
            try
            {
                NDF1 = new FC102C(com1);
                if (NDF1.IsOpen() == 1)
                {
                    NDF1COM.BackColor = Color.Green;
                }
                else
                {
                    NDF1COM.BackColor = Color.Red;
                }
            }
            catch (Exception ex) { NDF1COM.BackColor = Color.Red; }

            // NDF2
            try
            {
                NDF2 = new FC102C(com2);
                if (NDF2.IsOpen() == 1)
                {
                    NDF2COM.BackColor = Color.Green;
                }
                else
                {
                    NDF2COM.BackColor = Color.Red;
                }
            }
            catch (Exception ex) { NDF2COM.BackColor = Color.Red; }
        }

        private void modify_com_boxes()
        {
            string NDF1port = ConfigurationManager.AppSettings.Get("NDF1");
            string NDF2port = ConfigurationManager.AppSettings.Get("NDF2");
            NDF1COM.Text = NDF1port;
            NDF2COM.Text = NDF2port;

            check_com(NDF1port, NDF2port);

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
        #endregion

        private void buttonSet1_Click(object sender, EventArgs e)
        {
            string new_com = comboBox1.SelectedItem.ToString();
            NDF1COM.Text = new_com;

            UpdateAppSettings("NDF1", new_com);
            modify_com_boxes();
        }

        private void buttonSet2_Click(object sender, EventArgs e)
        {
            string new_com = comboBox2.SelectedItem.ToString();
            NDF2COM.Text = new_com;

            UpdateAppSettings("NDF2", new_com);
            modify_com_boxes();
        }
    }
}
