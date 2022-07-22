using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
using Common;
namespace SensorApp.Servis
{
    public class BlePhrase
    {
        public static List<BleDeviceModel> PhraseBlue(string com)
        {

            List<BleDeviceModel> ListOfBlue = new List<BleDeviceModel>();
            string[] phrase = com.Split(' ', '\t');
            int size = phrase.Length;
            string mac = "";
            double dbm = 0;
            List<Byte> ByteList;
            for (int i = 0; i < size; i++)
            {

                if (phrase[i] == "(new):")
                {
                    mac = phrase[i + 1];
                    
                }
                if (phrase[i] == "dBm")
                {
                    dbm = Double.Parse( phrase[i - 1]);
                    
                }
                if (phrase[i] == "Manufacturer:")
                {
                    string input = phrase[i + 1];
                    int input_size = input.Length;
                    input = input.Substring(1, input_size-2);
                    ByteList = HexStringToByteList.HexToByteList(input);
                    
                    BleDeviceModel tmp = new BleDeviceModel(mac, dbm, ByteList);
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

