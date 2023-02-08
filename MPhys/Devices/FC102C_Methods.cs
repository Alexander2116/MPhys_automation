using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MPhys.Devices
{
    internal class FC102C_Methods
    {
        const String FilterDLLName = @".\FilterWheel102_win32.dll";
        private FC102C_Methods()
        {

        }
        /// <summary>
        /// list all the possible port on this computer.
        /// </summary>
        /// <param name="serialNo">port list returned string include serial number and device descriptor, seperated by comma</param>
        /// <returns>non-negtive number: number of device in the list; negtive number : failed.</returns>
        [DllImport(FilterDLLName, EntryPoint = "List", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPorts(StringBuilder serialNo, UInt32 length);

        /// <summary>
        /// <p>get the fiterwheel id</p>
        /// <p>make sure the port was opened successful before call this function.</p>
        /// <p>make sure this is the correct device by checking the ID string before call this function.</p>
        /// </summary>
        /// <param name="hdl">handle of port.</param>
        /// <param name="d">output string (<255)</param>
        /// <returns>
        /// <p>0: success;</p>
        /// <p>0xEA: CMD_NOT_DEFINED;</p>
        /// <p>0xEB: time out;</p>
        /// <p>0xED: invalid string buffer;</p>
        /// </returns>
        [DllImport(FilterDLLName, EntryPoint = "GetId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetId(int hdl, StringBuilder d);

        /// <summary>
        ///  open port function.
        /// </summary>
        /// <param name="serialNo">serial number of the device to be opened, use GetPorts function to get exist list first.</param>
        /// <param name="nBaud">bit per second of port</param>
        /// <param name="timeout">set timeout value in (s)</param>
        /// <returns> non-negtive number: hdl number returned successfully; negtive number : failed.</returns>
        [DllImport(FilterDLLName, EntryPoint = "Open", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Open(String serialNo, int nBaud, int timeout);

        /// <summary>
        /// check opened status of port
        /// </summary>
        /// <param name="serialNo">serial number of the device to be checked.</param>
        /// <returns> 0: port is not opened; 1 : port is opened.</returns>
        [DllImport(FilterDLLName, EntryPoint = "IsOpen", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IsOpen(String serialNo);

        /// <summary>
        /// close current opend port
        /// </summary>
        /// <param name="hdl">handle of port.</param>
        /// <returns> 0: success; negtive number : failed.</returns>
        [DllImport(FilterDLLName, EntryPoint = "Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Close(Int32 hdl);

        /// <summary>
        /// <p>set fiterwheel's position to pos</p>
        /// <p>make sure the port was opened successful before call this function.</p>
        /// <p>make sure this is the correct device by checking the ID string before call this function.</p>
        /// </summary>
        /// <param name="hdl">handle of port.</param>
        /// <param name="pos">fiterwheel position</param>
        /// <returns>
        /// <p>0: success;</p>
        /// <p>0xEA: CMD_NOT_DEFINED;</p>
        /// <p>0xEB: time out;</p>
        /// <p>0xED: invalid string buffer;</p>
        /// </returns>
        [DllImport(FilterDLLName, EntryPoint = "SetPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPosition(Int32 hdl, Int32 pos);


        /// <summary>
        /// <p>get the fiterwheel current position</p>
        /// <p>make sure the port was opened successful before call this function.</p>
        /// <p>make sure this is the correct device by checking the ID string before call this function.</p>
        /// </summary>
        /// <param name="hdl">handle of port.</param>
        /// <param name="pos">fiterwheel actual position</param>
        /// <returns>
        /// <p>0: success;</p>
        /// <p>0xEA: CMD_NOT_DEFINED;</p>
        /// <p>0xEB: time out;</p>
        /// <p>0xED: invalid string buffer;</p>
        /// </returns>
        [DllImport(FilterDLLName, EntryPoint = "GetPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPosition(int hdl, out Int32 pos);

        /// <summary>
        /// <p>get the fiterwheel current position count</p>
        /// <p>make sure the port was opened successful before call this function.</p>
        /// <p>make sure this is the correct device by checking the ID string before call this function.</p>
        /// </summary>
        /// <param name="hdl">handle of port.</param>
        /// <param name="poscount">fiterwheel actual position count</param>
        /// <returns>
        /// <p>0: success;</p>
        /// <p>0xEA: CMD_NOT_DEFINED;</p>
        /// <p>0xEB: time out;</p>
        /// <p>0xED: invalid string buffer;</p>
        /// </returns>
        [DllImport(FilterDLLName, EntryPoint = "GetPositionCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPositionCount(int hdl, out int pos);

    }


}
