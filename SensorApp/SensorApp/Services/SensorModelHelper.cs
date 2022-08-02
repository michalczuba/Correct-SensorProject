using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
namespace SensorApp.Services
{
    public class SensorModelHelper
    {
        public static void DisplaySensorList(IEnumerable<BleDeviceModel> ListBlueTooth)
        {
            foreach (var val in ListBlueTooth)
            {
                string output = val.Mac + " ";
                int size = 0;
                int dbm = 0;
                foreach (var value in val.DBm)
                {
                    size++;
                    dbm += value;
                }
                dbm /= size;
                output += dbm.ToString() + " ";
                foreach (var value in val.Manufacture)
                {
                    output += value.ToString() + ",";
                }
                int output_size = output.Length;
                output = output.Substring(0, output_size - 1);
                output += " "+val.DBm.Count();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: "+output);
            }
        }
        public static void DisplayRssiMedian(BleDeviceModel model)
        {
            List<int> value = model.DBm;
            value.Sort();
            int value_size = value.Count;
            Console.WriteLine(value[value_size / 2]);
        }
        public static void DisplayRssiAvrage(BleDeviceModel model)
        {
            List<int> value = model.DBm;
            int avrage = 0;
            int value_size = value.Count;
            foreach (var val in value)
            {
                avrage += val;
            }
            Console.WriteLine(avrage / value_size);
        }
        public static void DisplayRssiWithWrongOffset(double Rw)
        {
            IEnumerable<BleDeviceModel> list = GlobalList.R().Where(x => x.Mediana < Rw).ToList();
            DisplaySensorList(list);
        }
    }
}
