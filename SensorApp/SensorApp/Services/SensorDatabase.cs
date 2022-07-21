using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Moduls;
namespace SensorApp.Servis
{
    public class SensorDatabase
    {
        public static List<SensorModel> ReadSensorsFromCsv(string fullPath)
        {
            using (
                var reader = new StreamReader(fullPath))
            {
                List<SensorModel> ListOfMac = new List<SensorModel>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var splited = line.Split(';');
                    SensorModel tmp = new SensorModel(splited[0], splited[1]);
                    ListOfMac.Add(tmp);
                }
                return ListOfMac;
            }
        }
    }
}

