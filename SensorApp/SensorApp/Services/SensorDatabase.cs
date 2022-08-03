using Common;
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
                    StringIsMac check = new StringIsMac();
                    check.IsMac(SplitedMacCorrection);
                    SensorModel tmp = new SensorModel(SplitedMacCorrection, splited[1]);
                    ListOfMac.Add(tmp);
                }
                return ListOfMac;
            }
        }
    }
}

