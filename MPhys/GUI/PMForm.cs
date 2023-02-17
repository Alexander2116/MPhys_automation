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
    public partial class PMForm : Form
    {
        public bool is_open;
        public PMForm()
        {
            InitializeComponent();
            is_open = true;
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;
        }
    }
}
