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
using JYCCDLib;

namespace MPhys
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            JYCCDLib.JYMCDClass a = new JYMCDClass();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }


        static void TestMain(string[] args)
        {
            PM100A pm;
            Console.WriteLine("Hello");
            try
            {
                //pm = new PM100A();
                //Console.WriteLine(pm.get_power());
                //pm.change_wavelength_correction(635);
                //pm.remove();
            }
            catch
            {
                Console.WriteLine("Couldn't connect to PM100A");
            }
            try
            {
                M9700 tc = new M9700("COM5");
                Console.WriteLine("Fine");
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(tc.Get_temperature());
                    Console.WriteLine(i);
                }
                tc.Set_temperature(295);
                Console.WriteLine(tc.Get_temperature());
                tc.Close();
            }
            catch (Exception ex) { }
            FC102C fc;
            try
            {
                fc = new FC102C("COM4");

                int hld = fc._hdl;

                Console.WriteLine(hld);

                if (hld < 0)
                { }
                else
                {
                    fc.SetPostion(3);
                }
            }

            catch { }
            Console.ReadKey();
        }
    }
}
