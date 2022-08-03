using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Modeles;
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
                    var SplitedMacCorrection = System.Text.RegularExpressions.Regex.Replace(splited[0], @"\s+", "");
                    SensorModel tmp = new SensorModel(SplitedMacCorrection, splited[1]);
                    ListOfMac.Add(tmp);
                }
                return ListOfMac;
            }
        }
    }
}

