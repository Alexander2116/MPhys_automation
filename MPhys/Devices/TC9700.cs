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
        private SerialPort _port;

        //
        public TC9700(string COM = "COM1", int Baud_Rate = 9600)
        {
            _port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            ;
        }

        // All commands are ASCII strings terminated by a<CR>
        public string get_temperature()
        {
            string command = "TA?\r"; // <CR> = \r
            send_command(command);
            return receive();
        }

        public void set_temperature(double temperature)
        {
            string command = "SET " + temperature.ToString() + "\r"; //<CR>
            send_command(command);
        }

        private void send_command(string command)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(command);
            //_port.Write(bytes, 0, bytes.Length);
            //_port.Write(command);
            foreach(byte b in bytes)
            {
                Console.WriteLine(b);
            }
            
        }
        private string receive()
        {
            string received = "";
            try
            {
                if (!(_port.IsOpen))
                    _port.Open();
                int count = _port.BytesToRead;
                byte[] ByteArray = new byte[count];
                _port.Read(ByteArray, 0, count);
                received = Encoding.ASCII.GetString(ByteArray);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't read data");
            }
            return received;
        }
    }

}
