using Common.Modeles;
using CsvHelper;
using System.Globalization;
namespace Common.ListModelsToModelCsv
{
    public class ListOfBleDeviceModelToCsv
    {
        public class PartialBleDiviceModel
        {

            public string Mac { get; set; }
            public int Rssi { get; set; }
            public string SerialNumber { get; set; } 
        }
        public static void ListOfBleDeviceModelToCsvFile(IEnumerable<BleDeviceModel> list,List<SensorModel> CsvFile)
        {


            var ListPB = new List<PartialBleDiviceModel>();
            foreach (var val in list)
            {
                int index = CsvFile.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                    continue;
                PartialBleDiviceModel PB = new PartialBleDiviceModel();
                PB.Mac = val.Mac;
                PB.Rssi = val.Mediana;
                PB.SerialNumber = CsvFile[index].SerialNumber;
                ListPB.Add(PB);

            }
            using (var writer = new StreamWriter("fileBleDeviceModel.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ListPB);
            }
        }
    }
}
