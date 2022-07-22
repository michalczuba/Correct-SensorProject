using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeles
{
    public class BleDeviceModel
    {
        public BleDeviceModel(string mac, double dBm, List<Byte> manufacture)
        {
            Mac = mac;
            DBm = dBm;
            Manufacture = manufacture;
        }
        public string Mac { private set; get; }
        public double DBm { private set; get; }
        public List<Byte> Manufacture { private set; get; }
    }
}
