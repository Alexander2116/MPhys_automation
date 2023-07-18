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
        private FW102C NDF1;
        private FW102C NDF2;
        private bool NDF1Open = false;
        private bool NDF2Open = false;

        public NDFForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;

            modify_com_boxes();

            timer1.Start();

        }

        #region Private functions 
        private void check_com()
        {
            // NDF1
            try
            {
                if (NDF1 != null && NDF1Open)
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
                if (NDF2 != null && NDF2Open)
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
            try
            {
                NDF1 = new FW102C(NDF1port);
                if (NDF1.IsOpen()==1)
                {
                    NDF1Open = true;
                }
                else
                {
                    NDF1Open = false;
                }
            }
            catch { }
            try
            {
                NDF2 = new FW102C(NDF2port);
                if (NDF2.IsOpen() == 1)
                {
                    NDF2Open = true;
                }
                else
                {
                    NDF2Open = false;
                }
            }
            catch { }

            check_com();

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
            if (comboBox1.SelectedItem != null )
            {
                string new_com = comboBox1.SelectedItem.ToString();
                NDF1COM.Text = new_com;

                UpdateAppSettings("NDF1", new_com);
                modify_com_boxes();
            }
        }

        private void buttonSet2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string new_com = comboBox2.SelectedItem.ToString();
                NDF2COM.Text = new_com;

                UpdateAppSettings("NDF2", new_com);
                modify_com_boxes();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ************
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
            // ************
            if (checkBox2.Checked)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (comboBox2.Items.Contains(s) == false)
                    {
                        comboBox2.Items.Add(s);
                    }
                }
            }
            // ************
            if (NDF1 == null || NDF2 == null)
            {
                modify_com_boxes();
            }
            // ************
            if (NDF1COM.BackColor == Color.Green && buttonNDF1pos.Enabled == false)
            {
                buttonNDF1pos.Enabled = true;
                comboNDF1pos.Enabled = true;
            }
            else if (buttonNDF1pos.Enabled) { }
            else
            {
                buttonNDF1pos.Enabled = false;
                comboNDF1pos.Enabled = false;
            }
            // ************
            if (NDF2COM.BackColor == Color.Green && buttonNDF2pos.Enabled == false)
            {
                buttonNDF2pos.Enabled = true;
                comboNDF2pos.Enabled = true;
            }
            else if (buttonNDF2pos.Enabled) { }
            else
            {
                buttonNDF2pos.Enabled = false;
                comboNDF2pos.Enabled = false;
            }
            //***********
            if (NDF1COM.BackColor == Color.Green)
            {
                textNDF1pos.Text = NDF1.GetPostion().ToString();
            }
            if (NDF2COM.BackColor == Color.Green)
            {
                textNDF2pos.Text = NDF2.GetPostion().ToString();
            }
            // ************
            if (NDF1.IsOpen() != 1)
            {
                NDF1COM.BackColor = Color.Red;
            }
            // ************
            if (NDF2.IsOpen() != 1)
            {
                NDF2COM.BackColor = Color.Red;
            }

            check_com();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox2.Enabled = true;
                buttonSet2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                buttonSet2.Enabled = false;
            }
        }

        private void buttonNDF1pos_Click(object sender, EventArgs e)
        {
            if (comboNDF1pos.SelectedItem != null)
            {
                string new_pos = comboNDF1pos.SelectedItem.ToString();
                NDF1.SetPostion(Int32.Parse(new_pos));
            }
        }

        private void buttonNDF2pos_Click(object sender, EventArgs e)
        {
            if (comboNDF2pos.SelectedItem != null)
            {
                string new_pos = comboNDF2pos.SelectedItem.ToString();
                NDF2.SetPostion(Int32.Parse(new_pos));
            }
        }
    }
}
