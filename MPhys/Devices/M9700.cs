/*============================================================
**
** Class:  TC9700
**
** Purpose: Connect to Scientific Instrument Temperature Controler M9700
**        : Set temperature
**        : Get temperature
** Notes:
*   Communication: RS232
*   Default Baud Rate: 9600
*   All commands are ASCII strings terminated by <CR> (/r, 13, 0x0D)
**
**
** Date:  31 January 2023
**
===========================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace MPhys.Devices
{
    class M9700
    {
        private SerialPort _port;
        private bool _continue;
        private int _Baud_Rate;
        private int _sleep_time;

        // Constructor, set COM channel and baud rate. Default value for M9700 is 9600.
        public M9700(string COM = "COM1", int Baud = 9600)
        {
            _Baud_Rate = Baud;
            _port = new SerialPort(COM, _Baud_Rate, Parity.None, 8, StopBits.One);
            _sleep_time = 10000/Baud; //ms
        }

        public void Open()
        {
            _port.Open();
        }


        /// <return> 
        /// <p> 0: Not Opened; </p>  
        /// <p> 1: Opened; </p> 
        /// </return> 
        public int IsOpen()
        {
            if (_port.IsOpen)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Send a command requesting temperature value
        // Send TA?<CR>, get TA[value]<CR>.
        public string Get_temperature()
        {
            string command = "TA?\r"; // <CR> = \r
            Send_command(command);
            string data = Receive("TA");
            data = data.Replace("TA", "");
            data = data.Replace("\r", "");
            //double data_double = Convert.ToDouble(data);
            return data;
        }

        // Send a command to set a temperature to 'temperature'
        public void Set_temperature(double temperature)
        {
            double temp = Math.Round(temperature, 3);
            string command = "SET " + temp.ToString() + "\r"; //<CR>
            Send_command(command);
        }

        // Send a command to set PID
        // Parameters: a,bbb,ccc,ddd. a={0,1} - control loop
        public void Set_PID(int control_loop, int P, int I, int D)
        {
            string command = "PID "+ control_loop.ToString()+ "," + P.ToString() + "," + I.ToString() + "," + D.ToString() + "\r";
            Send_command(command);
        }

        // Send a command to set mode
        public void Set_mode(int mode)
        {
            if(mode==1 || mode==2 || mode==3 || mode==4)
            {
                string command = "MODE " + mode.ToString() + "\r";
                Send_command(command);
            }
        }

        // sends string command to the device. It needs to be ASCII encoded 
        private void Send_command(string command)
        {
            if (!(_port.IsOpen))
                _port.Open();

            byte[] bytes = Encoding.ASCII.GetBytes(command);
            _port.Write(bytes, 0, bytes.Length);
            _port.Write(command);
            
        }

        // receive data from the device
        private string Receive(string initial)
        {
            string received = "";
            string data;
            Thread.Sleep(50);
            try
            {
                if (!(_port.IsOpen))
                    _port.Open();

                // read bytes from the device
                // read until you receive 
                _continue = true;

                while (_continue) 
                {
                    /*
                    int count = _port.BytesToRead;
                    if (count >2)
                    {
                        Thread.Sleep(20);
                        byte[] ByteArray = new byte[count];
                        _port.Read(ByteArray, 0, count);
                        foreach(byte ba in ByteArray)
                        {
                            //Console.WriteLine(ba);
                        }
                        received = (Encoding.ASCII.GetString(ByteArray));
                        _continue = false;
                    }*/

                    data = _port.ReadExisting();

                    // Read if data has (initial) ____ \r structure (that's what should be receive from the device)
                    if(data.Contains("\r") && data.Contains(initial))
                    {
                        received = data;
                        _continue = false;
                    }
                    Thread.Sleep(_sleep_time); // 1/9600 * 10000 = 1.04ms
                }

                _port.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't read data");
                Console.WriteLine(ex.Message);
            }
            return received;
        }

        public void Close()
        {
            _port.Close();
        }
    }

}
