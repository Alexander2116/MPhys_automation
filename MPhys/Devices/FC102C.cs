using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPhys.Devices;

namespace MPhys.Devices
{

    class FC102C
    {
        public FC102C()
        {
        }

        public void GetPorts()
        {
            var ports = new StringBuilder(256);
            FC102C_Methods.GetPorts(out ports);

            Console.WriteLine(ports);

        }

        public void Open(int pos)
        {
            //FC102C_Methods.Open();
        }

        public void SetPostion(int pos)
        {

        }

        
    }
}
