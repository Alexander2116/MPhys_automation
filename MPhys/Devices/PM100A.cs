/*============================================================
**
** Class:  PM100A
**
** Purpose: Connect to ThorLab PM100A meter
**        : Change wavelenth correction
**        : Measure power
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
using Thorlabs.PM100D_32.Interop;

namespace MPhys.Devices
{
    public class PM100A
    {
        private PM100D pm; // object = Power Meter, from Thorlabs.PM100D_32.Interop

        // For Resource_Name use syntax must be (from reference doc.):  USB[board]::0x1313::product id::serial number[::interface number][::INSTR]
        // Resource_Name: This parameter specifies the device (resource) with which to establish a communication session. 
        // ID_Query: This parameter specifies whether an identification query is performed during the initialization process. false = skip query.
        // Reset_Device: This parameter specifies whether the instrument is reset during the initialization process. false = no reset.
        public PM100A(string Resource_Name = "USB::0x1313::0x8079::P1001558::INSTR", bool ID_Query = true, bool Reset_Device = true)
        {
            pm = new PM100D(Resource_Name, ID_Query, Reset_Device);
        }
        ~PM100A() { 
            //Remove();
        }

        // Int value, lambda given in nm
        public void Change_wavelength_correction(double lambda)
        {
            pm.setWavelength(lambda);
        }

        // measures power and return power in uW
        public double Get_power()
        {
            double power;
            pm.measPower(out power);
            return power * Math.Pow(10, 6); // uW
        }

        // mode = true : auto range on
        public void AutoRange(bool mode)
        {
            pm.setPowerAutoRange(mode);
        }

        // Disconnects the connection between the program and the device, removes object 
        public void Remove()
        {
            pm.Dispose();
            pm = null;
        }

    }
}
