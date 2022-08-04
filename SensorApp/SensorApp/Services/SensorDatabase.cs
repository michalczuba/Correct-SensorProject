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
                    var splited = line.Split(';',',');
                    var SplitedMacCorrection = System.Text.RegularExpressions.Regex.Replace(splited[0], @"\s+", "");
                    StringIsMac check = new StringIsMac();
                    //Console.WriteLine(SplitedMacCorrection);
                    if (SplitedMacCorrection.Equals("mac",StringComparison.OrdinalIgnoreCase)|| SplitedMacCorrection.Equals("serialnumber",StringComparison.OrdinalIgnoreCase)|| SplitedMacCorrection.Equals("sn", StringComparison.OrdinalIgnoreCase))
                        continue;
                    bool MacCheck =check.IsMacBool(SplitedMacCorrection);
                    SensorModel tmp;
                    if (MacCheck)
                    {
                         tmp = new SensorModel(splited[0], splited[1]);
                    }
                    else 
                    {
                         tmp = new SensorModel(splited[1], splited[0]);
                    }
                        
                    
                    ListOfMac.Add(tmp);
                }
                return ListOfMac;
            }
        }
    }
}

