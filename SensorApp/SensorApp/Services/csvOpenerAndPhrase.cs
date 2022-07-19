using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonStaff.Moduls;
namespace SensorApp.Servis
{
    public class csvOpenerAndPhrase
    {
        public static List<SensorModel> Open(string fullPath)
        {
            using (
                var reader = new StreamReader(fullPath))
            {
                List<SensorModel> ListOfMac = new List<SensorModel>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var splited = line.Split(';');
                    //Console.WriteLine(splited[0] + "\t" + splited[1]);
                    SensorModel tmp = new SensorModel(splited[0], splited[1]);
                    ListOfMac.Add(tmp);
                }
                //foreach (var val in ListOfMac)
                //{
                //    Console.WriteLine(val.Mac + "\t" + val.SerialNumber);
                //}
                //Console.ReadKey();
                return ListOfMac;
            }
        }
    }
}

