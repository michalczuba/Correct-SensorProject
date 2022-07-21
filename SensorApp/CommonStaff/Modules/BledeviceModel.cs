using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Moduls
{
    public class BleDeviceModel
    {
        public BleDeviceModel(string mac,string dBm,string manufacture)
        {
            Mac = mac;
            DBm = dBm;  
            Manufacture = manufacture;  
        }
        public string Mac { private set; get; }
        public string DBm { private set; get; } 
        public string Manufacture { private set; get; }
    }
}
