using Common.Modeles;
namespace SensorApp.Services
{
    public class SensorModelHelper
    {
        public static int DisplaySensorListMissing(List<SensorModel> CsvFile)
        {
            List<BleDeviceModel> TmpList = GlobalList.R();
            int tmp = 0;
            foreach (var val in CsvFile)//Missings:
            {
                if (TmpList.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase)) == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Missing: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{val.Mac} ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(val.SerialNumber);
                    Console.ForegroundColor = ConsoleColor.White;
                    tmp++;
                }
            }
            return tmp;
        }
        public static void DisplaySensorListWarning(IEnumerable<BleDeviceModel> ListBlueTooth, List<SensorModel> CsvFile)
        {

            foreach (var val in ListBlueTooth)//Warnings
            {
                int index = CsvFile.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                    continue;
                string output = val.Mac + " " + CsvFile[index].SerialNumber + " ";

                int dbm = val.Avrege;

                output += dbm.ToString();
                //foreach (var value in val.Manufacture)
                //{
                //    output += value.ToString() + ",";
                //}
                //int output_size = output.Length;
                //output = output.Substring(0, output_size - 1);
                output += " " + val.DBm.Count();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Warning: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(output);
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
        public static int DisplayRssiWithWrongOffset(double Rw, List<SensorModel> CsvFile)
        {
            IEnumerable<BleDeviceModel> list = GlobalList.R().Where(x => x.Mediana < Rw).ToList();
            DisplaySensorListWarning(list, CsvFile);
            return list.Count();
        }
        public static int DisplayAdvWithWrongOffset(double offsetup,double offsetdown,int index, List<SensorModel> CsvFile)
        {
            var list = GlobalList.R();
            int tmp = 0;
            foreach(var val in list)
            {
                int indexVal = CsvFile.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                if (indexVal == -1)
                    continue;
                if (val.Manufacture.Count()>=index)
                {
                    if(val.Manufacture.ElementAt(index-1)>offsetup || val.Manufacture.ElementAt(index - 1) < offsetdown)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Warning adv.: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{CsvFile[indexVal].Mac} {CsvFile[indexVal].SerialNumber} Has wrong  adv on {index} place!");
                        tmp++;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Warning adv.: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" {CsvFile[indexVal].Mac} {CsvFile[indexVal].SerialNumber} Has wrong size of adv!");
                    tmp++;
                }
            }
            return tmp;
        }
    }
}
