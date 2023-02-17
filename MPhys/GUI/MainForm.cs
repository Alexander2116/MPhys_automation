using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPhys.GUI
{
    public partial class MainForm : Form
    {
        // All forms
        private NDFForm NDFf;
        private PMForm PMf;
        //private TempForm Tf;
        //private SpecForm Sf;

        public MainForm()
        {
            InitializeComponent();
        }

        private void enable_buttons()
        {
            buttonNDF.Enabled = true;
            buttonPM.Enabled = true;
            buttonTemp.Enabled = true;
            buttonSpec.Enabled = true;
            buttonAuto.Enabled = true;

        }


        private void buttonNDF_Click(object sender, EventArgs e)
        {
            enable_buttons();
            if (NDFf == null)
            {
                NDFf = new NDFForm();
                /*
                NDFf.Location = new Point(60, 26);
                NDFf.ControlBox = false;
                NDFf.TopLevel = false;
                NDFf.TopMost = true;*/
                this.Controls.Add(NDFf);

                buttonNDF.Enabled = false;
                NDFf.Show();
                NDFf.BringToFront();
            }
            else
            {
                Console.WriteLine("Sss");
                NDFf.TopMost = true;
                buttonNDF.Enabled = false;
                NDFf.BringToFront();
                //NDFf.Show();
            }

        }

        private void buttonPM_Click(object sender, EventArgs e)
        {
            enable_buttons();
            if (PMf == null)
            { 
                PMf = new PMForm();
                /*
                PMf.Location = new Point(60, 26);
                PMf.ControlBox = false;
                PMf.TopLevel = false;
                PMf.TopMost = true;*/
                this.Controls.Add(PMf);

                buttonPM.Enabled = false;
                PMf.Show();
                PMf.BringToFront();
            }
            else
            {
                Console.WriteLine("Sss");
                PMf.TopMost = true;
                buttonPM.Enabled = false;
                PMf.BringToFront();
                //PMf.Show();
            }
            
        }

        private void buttonTemp_Click(object sender, EventArgs e)
        {

        }

        private void buttonSpec_Click(object sender, EventArgs e)
        {

        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {

        }
    }
}
