using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPhys.Devices;
using System.IO.Ports;
using System.Windows.Forms;
using MPhys.GUI;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data;
using MPhys.MyFunctions;

namespace MPhys
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

       
    }
}
