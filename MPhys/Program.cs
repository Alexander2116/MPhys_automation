﻿using System;
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
                //pm = new PM100A();
                //Console.WriteLine(pm.get_power());
                //pm.change_wavelength_correction(635);
                //pm.remove();
            }
            catch{
                Console.WriteLine("Couldn't connect to PM100A");
            }
            try
            {
                //TC9700 tc = new TC9700("COM3");
                for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine(tc.get_temperature());
                }
                //Console.WriteLine(tc.get_temperature());
                //tc.close();
            }
            catch (Exception ex){ }
            FC102C fc;
            try
            {
                fc = new FC102C("COM4");
                //fc.GetPorts();
                int hld = fc.Open();
                Console.WriteLine(hld);
                //fc.SetPostion(hld,3);
                Console.WriteLine(fc.GetPostionCount(hld));
                fc.Close();
                //Console.WriteLine(fc.GetPostion());
            }
            catch { }
            Console.ReadKey();
        }
    }
}