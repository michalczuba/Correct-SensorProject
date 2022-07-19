using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonStaff.Moduls;
namespace SensorApp.Servis
{
    public class BlePhrase
    {
        public static List<BleDeviceModel> PhraseBlue(string com)
        {

            List<BleDeviceModel> ListOfBlue = new List<BleDeviceModel>();
            //Nowa
            string[] phrase = com.Split(' ', '\t');
            int size = phrase.Length;
            //Console.WriteLine("|"+phrase[13]+ "|");
            //Console.WriteLine(phrase[14]);
            string mac = "", id = "", nb = "";
            for (int i = 0; i < size; i++)
            {

                if (phrase[i] == "(new):")
                {
                    mac = phrase[i + 1];
                    //Console.WriteLine(mac);
                }
                if (phrase[i] == "dBm")
                {
                    id = phrase[i - 1];
                    //Console.WriteLine(id);
                }
                if (phrase[i] == "Manufacturer:")
                {
                    nb = phrase[i + 1];
                    //Console.WriteLine(nb);
                    BleDeviceModel tmp = new BleDeviceModel(mac, id, nb);
                    ListOfBlue.Add(tmp);
                }
            }
            return ListOfBlue;
            /*Działa
            int mac = 8;
            int id = 10;
            int nb = 14;
            int x = 12;
            string[] phrase = com.Split(' ');
            int size = phrase.Length;
            size = (size - nb) / x;
            for(int i=0; i < size; i++)
            {
                Sensor tmp = new Sensor(phrase[mac + i * x], phrase[id + i * x], phrase[nb + i * x]);
                ListOfBlue.Add(tmp);
            }
            */
        }
    }
}

