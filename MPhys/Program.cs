using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPhys.Devices;
using System.IO.Ports;
using System.Windows.Forms;
using MPhys.GUI;
using System.Diagnostics;
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
            System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
            myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            
            //using (Process p = Process.GetCurrentProcess())
            //    p.PriorityClass = ProcessPriorityClass.RealTime; // Highest possible priority "High" is lower than that
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

       
    }
}
