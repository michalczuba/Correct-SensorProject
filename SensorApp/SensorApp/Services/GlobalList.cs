using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
namespace SensorApp.Services
{
    static class GlobalList
    {
        static IEnumerable<BleDeviceModel> _list;
        static GlobalList()
        {
            _list = new List<BleDeviceModel>();
        }
        public static void Add(List<BleDeviceModel> list)
        {

        }
    }
}
