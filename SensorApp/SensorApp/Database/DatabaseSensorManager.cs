using Common;
using Common.Modeles;
using SensorApp.Servis;
namespace SensorApp.Lists
{
    public class DatabaseSensorManager
    {
        public List<SensorModel> SensorList { private set; get; }
        public void ReadFromFile(string name)
        {
            SensorList = new List<SensorModel>();
            string fullPath = FilePath.PathToFile(name);
            SensorList = SensorDatabase.ReadSensorsFromCsv(fullPath);//this sepccific line open csv file and phrase it in list with have 2 spaces like this <##,##>;
        }
    }
}
