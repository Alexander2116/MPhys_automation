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
    class TC9700
    {
        private SerialPort _port;
        private bool _continue;
        private int _Baud_Rate;
        private int _sleep_time;

        // Constructor, set COM channel and baud rate. Default value for M9700 is 9600.
        public TC9700(string COM = "COM1", int Baud = 9600)
        {
            _Baud_Rate = Baud;
            _port = new SerialPort(COM, _Baud_Rate, Parity.None, 8, StopBits.One);
            _sleep_time = 10000/Baud; //ms
        }

        // Send a command requesting temperature value
        // Send TA?<CR>, get TA[value]<CR>.
        public string get_temperature()
        {
            string command = "TA?\r"; // <CR> = \r
            send_command(command);
            string data = receive("TA");
            //data = data.Replace("TA", "");
            //double data_double = Convert.ToDouble(data);
            return data;
        }

        // Send a command to set a temperature to 'temperature'
        public void set_temperature(double temperature)
        {
            string command = "SET " + temperature.ToString() + "\r"; //<CR>
            send_command(command);
        }

        // sends string command to the device. It needs to be ASCII encoded 
        private void send_command(string command)
        {
            if (!(_port.IsOpen))
                _port.Open();

            byte[] bytes = Encoding.ASCII.GetBytes(command);
            _port.Write(bytes, 0, bytes.Length);
            _port.Write(command);
            /*foreach(byte b in bytes)
            {
                Console.WriteLine(b);
            }*/
            //_port.Close();
            
        }

        // receive data from the device
        private string receive(string initial)
        {
            string received = "";
            string data;
            Thread.Sleep(50);
            try
            {
                if (!(_port.IsOpen))
                    _port.Open();

                // The number of bytes present in device's buffer


                // read bytes from the device
                // read until you receive 
                _continue = true;

                while (_continue) 
                {
                    int count = _port.BytesToRead;
                    if (count >2)
                    {
                        Thread.Sleep(20);
                        //Console.WriteLine(count);
                        byte[] ByteArray = new byte[count];
                        _port.Read(ByteArray, 0, count);
                        foreach(byte ba in ByteArray)
                        {
                            //Console.WriteLine(ba);
                        }
                        received = (Encoding.ASCII.GetString(ByteArray));
                        _continue = false;
                    }
                    //_port.Read(ByteArray, 0, count);
                    data = _port.ReadExisting();
                    //int data = _port.ReadByte();
                    //received = Encoding.ASCII.GetString(BitConverter.GetBytes(data));

                    //received = Encoding.ASCII.GetString(ByteArray);
                    //Console.Write(data);
                    if(data.Contains("\r") && data.Contains(initial))
                    {
                        //Console.WriteLine("Stop \r");
                        received = data;
                        _continue = false;
                    }
                    Thread.Sleep(_sleep_time); // 1/9600 * 10000 = 1.04ms
                }

                // encode to string
                //received = Encoding.ASCII.GetString(ByteArray);
                //Console.WriteLine("End");

                _port.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't read data");
                Console.WriteLine(ex.Message);
            }
            return received;
        }

        public void close()
        {
            _port.Close();
        }
    }

}
