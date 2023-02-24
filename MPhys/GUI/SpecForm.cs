using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JYMONOLib;
using JYCONFIGBROWSERCOMPONENTLib;
using JYSYSTEMLIBLib;

namespace MPhys.GUI
{
    public partial class SpecForm : Form
    {
        private Boolean mbEmulate;
        private Boolean mbForceInit;
        private Boolean mbInitialized;
        private Boolean mbPositionChanged;
        private Boolean mbSlitFrontEntranceChanged;
        private Boolean mbSlitSideEntranceChanged;
        private Boolean mbSlitFrontExitChanged;
        private Boolean mbSlitSideExitChanged;
        private String sMonoDevId;
        private String sMonoName;

        public JYConfigBrowerInterface mConfigBrowser;
        private MonochromatorClass mMono; // ??? Why ??? It works in the different example

        public SpecForm()
        {
            InitializeComponent();
            this.Location = new Point(60, 26);
            this.ControlBox = false;
            this.TopLevel = false;
            this.TopMost = true;
        }
    }
}
