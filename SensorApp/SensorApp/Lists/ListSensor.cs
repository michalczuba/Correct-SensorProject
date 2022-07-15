using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  CommonStaff.Moduls;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    internal class ListSensor
    {
        public List<SensorModel> SensorList { private set; get; } = new List<SensorModel>();
        public void ReadFromFile(string name)
        {
            SensorList = new List<SensorModel>();
            SensorList = csvOpener.Open(name);
        }
    }
}
