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
        static List<BleDeviceModel> _list;
        static GlobalList()
        {
            _list = new List<BleDeviceModel>();
        }
        public static void ToAdd(IEnumerable<BleDeviceModel> list)
        {
            foreach(var model in list)
            {
                if (_list.Exists(x => x.Mac == model.Mac))
                {
                    int index = _list.FindIndex(x => x.Mac == model.Mac);
                    foreach(var val in model.DBm)
                    {
                        _list[index].AddToRSSI(val);
                    }
                } 
                else
                {
                    _list.Add(model);   
                }
                    
            }
           
        }
        public static List<BleDeviceModel> R()
        {
            return _list;
        }
    }
}
