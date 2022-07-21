using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Common.Modeles;
using Common;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    public class DatabaseSensorManager
    {
        public List<SensorModel> SensorList { private set; get; } = new List<SensorModel>();
        public void ReadFromFile(string name)
        {
            SensorList = new List<SensorModel>();
            string fullPath = FilePath.PathToFile(name);
            SensorList = SensorDatabase.ReadSensorsFromCsv(fullPath);//this sepccific line open csv file and phrase it in list with have 2 spaces like this <##,##>;
        }
    }
}
