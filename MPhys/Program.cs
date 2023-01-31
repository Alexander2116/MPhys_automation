using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPhys.Devices;
using System.IO.Ports;

namespace MPhys
{
    class Program
    {
        static void Main(string[] args)
        {
            PM100A pm;
            Console.WriteLine("Hello");
            try
            {
                pm = new PM100A();
                //Console.WriteLine(pm.get_power());
                //pm.change_wavelength_correction(635);
                pm.remove();
            }
            catch{
                Console.WriteLine("Couldn't connect to PM100A");
            }

            Console.ReadKey();
        }
    }
}
