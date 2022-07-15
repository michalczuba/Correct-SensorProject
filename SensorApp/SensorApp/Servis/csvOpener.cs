using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonStaff.Moduls;
namespace SensorApp.Servis
{
    internal class csvOpener
    {
        public static List<SensorModel> Open(string name)
        {
            string fullPath = Path.GetFullPath(name); //f.FullName;//Path.GetFullPath(@"SensorList.csv");

            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File of that name dosen't exist or it's not in the same catlog as program.\n");
                Console.WriteLine("Reboot Program.\n");
                Environment.Exit(0);
            }

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

