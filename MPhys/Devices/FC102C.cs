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
        private string _port;
        public FC102C(string port)
        {
            _port = port;
        }

        public void GetPorts()
        {
            var ports = new StringBuilder(256);
            FC102C_Methods.GetPorts(ports);

            Console.WriteLine(ports);

        }

        public int Open(int BaudRate = 9600)
        {
            var hld = FC102C_Methods.Open(_port, BaudRate, 10);
            return (int)hld;
        }

        public int Close(int BaudRate = 9600)
        {
            var hld = FC102C_Methods.Close(_port, BaudRate, 10);
            return (int)hld;
        }

        public void SetPostion(int hld,int pos)
        {
            FC102C_Methods.SetPosition(hld,pos);
        }

        public int GetPostion()
        {
            int pos =0;
            int hld = Open();
            FC102C_Methods.GetPosition(hld,(IntPtr)pos);
            return pos;
        }

        public int GetPostionCount(int hld)
        {
            int pos = 0;
            FC102C_Methods.GetPositionCount(hld, pos);
            return pos;
        }


    }
}
