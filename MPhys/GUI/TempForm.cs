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
        private M9700 TempDev;
        private bool DeviceOpen = false;


        public TempForm()
        {
            // Initialize and set possition of the window
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            comboBoxModes.SelectedIndex = 0;

            modify_com_boxes();

            timer1.Start();

        }

        private void buttonSet1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string new_com = comboBox1.SelectedItem.ToString();
                textM9700COM.Text = new_com;

                UpdateAppSettings("M9700", new_com);
                modify_com_boxes();
            }
        }


        private void modify_com_boxes()
        {
            string M9700port = ConfigurationManager.AppSettings.Get("M9700");
            textM9700COM.Text = M9700port;
            try
            {
                TempDev = new M9700(M9700port);
                TempDev.Open();
                TempDev.Close();
                DeviceOpen = true;
            }
            catch { }

            check_com();

        }

        private void check_com()
        {
            // M9700
            try
            {
                //TempDev = new M9700(com1);
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

        private void timer1_Tick(object sender, EventArgs e)
        {

            if(TempDev != null && DeviceOpen)
            {
                try
                {
                    textBoxTemp.Text = TempDev.Get_temperature(); 
                }
                catch { }
            }
            if (checkBox1.Checked)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBox1.Items.Contains(s) == false)
                    {
                        comboBox1.Items.Add(s);
                    }
                }
            }
            if(TempDev == null)
            {
                modify_com_boxes();
            }
            // *********
            if (textM9700COM.BackColor == Color.Green && buttonSetTemp.Enabled == false)
            {
                buttonSetTemp.Enabled = true;
                textTempWrite.Enabled = true;
                groupBoxPID.Enabled = true;
                groupBoxMode.Enabled = true;

            }
            else if (buttonSetTemp.Enabled) { }
            else
            {
                buttonSetTemp.Enabled = false;
                textTempWrite.Enabled = false;
                groupBoxPID.Enabled = false;
                groupBoxMode.Enabled = false;
            }
            check_com();
            
        }

        private void buttonSetTemp_Click(object sender, EventArgs e)
        {
            string text = textTempWrite.Text.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                comboBox1.Enabled = true;
                buttonSet1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                buttonSet1.Enabled = false;
            }
        }

        private void buttonPID_Click(object sender, EventArgs e)
        {
            int CL, P, I, D;
            CL = int.Parse(comboBoxCL.SelectedItem.ToString());
            try
            {
                P = int.Parse(textBoxP.Text.ToString());
                I = int.Parse(textBoxI.Text.ToString());
                D = int.Parse(textBoxD.Text.ToString());
                if (P > 999 || I > 999 || D > 999 )
                {
                    MessageBox.Show("Entered P, I, D maximal values are 999.");
                    return;
                }
                TempDev.Set_PID(CL, P, I, D);
            }
            catch
            {
                MessageBox.Show("Entered P, I, D values must be an int in format of 'xxx'.");
            }

        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            int mode = int.Parse(comboBoxModes.SelectedItem.ToString());

            TempDev.Set_mode(mode);
        }
    }

   
}
