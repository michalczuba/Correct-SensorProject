using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    public class ScannsedSensorManager
    {
        public List<BleDeviceModel> BluetoothList { private set; get; } = new List<BleDeviceModel>();
        public void ReadBlue(string com)
        {
            BluetoothList = new List<BleDeviceModel>();
            BluetoothList = BlePhrase.PhraseBlue(com);// this line will make list of <mac,dBm,manufacture> from blescan result of devices
        }
    }
}
