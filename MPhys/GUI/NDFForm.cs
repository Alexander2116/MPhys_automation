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

namespace MPhys.GUI
{
    public partial class NDFForm : Form
    {
        public bool is_open;

        public NDFForm()
        {
            InitializeComponent();
            is_open = true;
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;
            NDF1COM.Text = ConfigurationManager.AppSettings.Get("NDF1");
            NDF2COM.Text = ConfigurationManager.AppSettings.Get("NDF2");
        }
    }
}
