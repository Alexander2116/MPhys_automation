/*============================================================
**
** Class:  TC9700
**
** Purpose: Connect to Scientific Instrument Temperature Controler 9700
**        : Set temperature
**        : Get temperature
** Notes:
*   Communication: RS232
*   Default Baud Rate: 9600
**
**
** Date:  31 January 2023
**
===========================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MPhys.Devices
{
    class TC9700
    {
        private SerialPort port;

        //
        public TC9700(string COM = "COM1", int Baud_Rate = 9600)
        {
            port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        }

        // All commands are ASCII strings terminated by a<CR>
        public string get_temperature()
        {
            string command = "TA?<CR>";
            return "";
        }
        public void set_temperature(double temperature)
        {
            string command = "SET " + temperature.ToString() + "<CR>";
        }
    }

}
