using Common.Modeles;
namespace SensorApp.Services
{
    public class SensorModelHelper
    {
        public static void DisplaySensorList(IEnumerable<BleDeviceModel> ListBlueTooth, List<SensorModel> CsvFile)
        {
            foreach (var val in ListBlueTooth)//Warnings
            {
                int index = CsvFile.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                    continue;
                string output = val.Mac + " " + CsvFile[index].SerialNumber + " ";

                int dbm = val.Mediana;

                output += dbm.ToString();
                //foreach (var value in val.Manufacture)
                //{
                //    output += value.ToString() + ",";
                //}
                //int output_size = output.Length;
                //output = output.Substring(0, output_size - 1);
                output += " " + val.DBm.Count();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Warning: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(output);
            }
            List<BleDeviceModel> TmpList =GlobalList.R();
            foreach(var val in CsvFile)//Missings:
            {
                if(TmpList.FindIndex(x => x.Mac.Equals(val.Mac,StringComparison.OrdinalIgnoreCase))==-1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Missing: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{val.Mac} ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(val.SerialNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                }
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
        public static void DisplayRssiWithWrongOffset(double Rw, List<SensorModel> CsvFile)
        {
            IEnumerable<BleDeviceModel> list = GlobalList.R().Where(x => x.Mediana < Rw).ToList();
            DisplaySensorList(list, CsvFile);
        }
    }
}
