using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  CommonStaff.Moduls;
using CommonStaff;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    internal class ListSensor
    {
        public List<SensorModel> SensorList { private set; get; } = new List<SensorModel>();
        public void ReadFromFile(string name)
        {
            SensorList = new List<SensorModel>();
            string fullPath = FilePath.PathToFile(name);
            SensorList = csvOpener.Open(fullPath);//this sepccific line open csv file and phrase it in list with have 2 spaces like this <##,##>;
        }
    }
}
