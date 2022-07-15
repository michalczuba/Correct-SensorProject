using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonStaff.Moduls;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    internal class ListBluetooth
    {
        public List<BledeviceModel> BluetoothList { private set; get; } = new List<BledeviceModel>();
        public void ReadBlue(string com)
        {
            BluetoothList = new List<BledeviceModel>();
            BluetoothList = BlePhrase.ReadBlue(com);
        }
    }
}
