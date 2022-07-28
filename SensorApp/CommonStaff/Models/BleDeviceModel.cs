using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeles
{
    public class BleDeviceModel
    {
        public BleDeviceModel(string mac,int dBm,List<byte> manufacture)
        {
            DBm = new List<int>();
            Mac = mac;
            DBm.Add(dBm);  
            Manufacture = manufacture;  
        }
        public void AddToRSSI(int dBm)
        {
            DBm.Add(dBm);
        }
        public string Mac { private set; get; }
        public List<int> DBm { private set; get; } 
        public List<byte> Manufacture  { private set; get; }
    }
}
