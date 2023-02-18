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
        private TempForm Tf;
        //private SpecForm Sf;

        public MainForm()
        {
            InitializeComponent();
            NDFf = new NDFForm();
            this.Controls.Add(NDFf);
            buttonNDF.Enabled = false;
            NDFf.Show();
            NDFf.BringToFront();
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
                this.Controls.Add(NDFf);

                buttonNDF.Enabled = false;
                NDFf.Show();
                NDFf.BringToFront();
            }
            else
            {
                NDFf.TopMost = true;
                buttonNDF.Enabled = false;
                NDFf.BringToFront();
            }

        }

        private void buttonPM_Click(object sender, EventArgs e)
        {
            enable_buttons();
            if (PMf == null)
            { 
                PMf = new PMForm();
                this.Controls.Add(PMf);

                buttonPM.Enabled = false;
                PMf.Show();
                PMf.BringToFront();
            }
            else
            {
                PMf.TopMost = true;
                buttonPM.Enabled = false;
                PMf.BringToFront();
            }
            
        }

        private void buttonTemp_Click(object sender, EventArgs e)
        {
            enable_buttons();
            if (Tf == null)
            {
                Tf = new TempForm();
                this.Controls.Add(Tf);

                buttonTemp.Enabled = false;
                Tf.Show();
                Tf.BringToFront();
            }
            else
            {
                Tf.TopMost = true;
                buttonTemp.Enabled = false;
                Tf.BringToFront();
            }
        }

        private void buttonSpec_Click(object sender, EventArgs e)
        {

        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {

        }
    }
}
