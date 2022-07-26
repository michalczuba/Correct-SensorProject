using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeles
{
    public class SensorModel
    {
        public SensorModel(string mac,string serialNumber)
        {
            Mac = mac;
            SerialNumber = serialNumber;
        }
        public string Mac { private set; get; }
        public string SerialNumber { private set; get; }
    }
}
