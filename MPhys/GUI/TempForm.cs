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
using System.IO.Ports;

namespace MPhys.GUI
{
    public partial class TempForm : Form
    {
        M9700 TempDev;

        public TempForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            string M9700port = ConfigurationManager.AppSettings.Get("M9700");
            textM9700COM.Text = M9700port;

            TempDev = new M9700(M9700port);

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }

            check_com(M9700port);
        }

        private void buttonSet1_Click(object sender, EventArgs e)
        {
            string new_com = comboBox1.SelectedItem.ToString();
            textM9700COM.Text = new_com;

            UpdateAppSettings("M9700", new_com);
            modify_com_boxes();
        }


        private void modify_com_boxes()
        {
            string M9700port = ConfigurationManager.AppSettings.Get("M9700");
            textM9700COM.Text = M9700port;

            check_com(M9700port);

        }

        private void check_com(string com1)
        {
            string M9700port = ConfigurationManager.AppSettings.Get("M9700");
            // M9700
            try
            {
                TempDev = new M9700(M9700port);
                TempDev.Open();
                if (TempDev.IsOpen()==1)
                {
                    textM9700COM.BackColor = Color.Green;
                }
                else
                {
                    textM9700COM.BackColor = Color.Red;
                }
                TempDev.Close();
            }
            catch
            {
                textM9700COM.BackColor = Color.Red;
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
    }

   
}
