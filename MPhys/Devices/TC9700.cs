/*============================================================
**
** Class:  TC9700
**
** Purpose: Connect to Scientific Instrument Temperature Controler 9700
**        : Set temperature
**        : Get temperature
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

        public TC9700()
        {

        }
    }
    class SerialPortProgram
    {
        // Create the serial port with basic settings
        private SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        [STAThread]
        static void Main(string[] args)
        {
            // Instatiate this class
            new SerialPortProgram();
        }

        private SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");

            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications
            port.Open();
        }

        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine(port.ReadExisting());
        }
    }
}
