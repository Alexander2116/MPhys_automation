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
        // Port COM[]
        private String _port;
        // handle of port
        public Int32 _hdl;
        public FC102C(String port)
        {
            _port = port;
        }

        public void Enter_handler(int hdl)
        {
            _hdl = hdl;
        }

        public void GetPorts()
        {
            var ports = new StringBuilder(256);
            FC102C_Methods.GetPorts(ports,256);

            Console.WriteLine(ports);

        }

        public int GetID()
        {
            var ID = new StringBuilder(256);
            var res = FC102C_Methods.GetId(_hdl, ID);

            Console.WriteLine(ID);
            return (int)res;
        }

        // Open connection
        // From documentation initial BaudRate = 115200
        public int Open(int BaudRate = 115200)
        {
            var res = FC102C_Methods.Open(_port, BaudRate, 10);
            return (int)res;
        }

        /// <return> 
        /// <p> 0: Not Opened; </p>  
        /// <p> 1: Opened; </p> 
        /// </return> 
        public int IsOpen()
        {
            var ret = FC102C_Methods.IsOpen(_port);
            // 0: Not Opened ; 1: Opened 
            return (int)ret;
        }

        /// <return> 
        /// <p> 0: Closed; </p>  
        /// <p> Negative number: Fail; </p> 
        /// </return> 
        public int Close()
        {
            var ret = FC102C_Methods.Close(_hdl);
            // 0: Closed ; Negative number: Fail
            return (int)ret;
        }

        // 
        public void SetPostion(Int32 pos)
        {
            var ret = FC102C_Methods.SetPosition(_hdl,pos);
            //return (int)ret;
        }

        // Get CURRENT position
        public int GetPostion()
        {
            Int32 pos = 0;
            var ret = FC102C_Methods.GetPosition(_hdl, out pos);

            return pos;
        }

        // For FW102C it is pos=6
        public int GetPostionCount()
        {
            int pos = 0;
            FC102C_Methods.GetPositionCount(_hdl, out pos);

            return pos;
        }


    }
}
