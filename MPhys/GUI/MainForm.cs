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

namespace MPhys.GUI
{
    public partial class MainForm : Form
    {
        // All forms
        private NDFForm NDFf;
        private PMForm PMf;
        private TempForm Tf;
        private SpecForm Sf;
        private AutoForm Af;
        private TestForm TestF;

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
            buttonTest.Enabled = true;
        }
        private void make_inactive()
        {
            if(NDFf != null)
            {
                NDFf.Dispose();
                NDFf = null;
            }
            if(PMf != null)
            {
                PMf.Dispose();
                PMf = null;
            }
            if(Tf != null)
            {
                Tf.Dispose();
                Tf = null;
            }
            if(Sf != null)
            {
                Sf.Dispose();
                Sf = null;
            }
            if(Af != null)
            {
                Af.Dispose();
                Af = null;
            }
            if (TestF != null)
            {
                TestF.Dispose();
                TestF = null;
            }

        }


        private void buttonNDF_Click(object sender, EventArgs e)
        {
            enable_buttons();
            make_inactive();
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
            make_inactive();
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
            make_inactive();
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
            enable_buttons();
            make_inactive();
            if (Sf == null)
            {
                Sf = new SpecForm();
                this.Controls.Add(Sf);

                buttonSpec.Enabled = false;
                Sf.Show();
                Sf.BringToFront();
            }
            else
            {
                Sf.TopMost = true;
                buttonSpec.Enabled = false;
                Sf.BringToFront();
            }
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            enable_buttons();
            make_inactive();
            if (Af == null)
            {
                Af = new AutoForm();
                this.Controls.Add(Af);

                buttonAuto.Enabled = false;
                Af.Show();
                Af.BringToFront();
            }
            else
            {
                Af.TopMost = true;
                buttonAuto.Enabled = false;
                Af.BringToFront();
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            enable_buttons();
            make_inactive();
            if (TestF == null)
            {
                TestF = new TestForm();
                this.Controls.Add(TestF);

                buttonTest.Enabled = false;
                TestF.Show();
                TestF.BringToFront();
            }
            else
            {
                TestF.TopMost = true;
                buttonTest.Enabled = false;
                TestF.BringToFront();
            }
        }
    }
}
