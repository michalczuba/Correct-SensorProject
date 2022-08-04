using Common.Modeles;
using CsvHelper;
using System.Globalization;
namespace Common.ListModelsToModelCsv
{
    public class ListOfSpecificModelToCsv
    {
        public class PartialBleDiviceModel
        {
            public string SerialNumber { get; set; }
            public string Mac { get; set; }
            public int Rssi { get; set; }
            
        }
        public class PartialSensorModel
        {
            public string SerialNumber { get; set; }
            public string Mac { get; set; }

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
            using (var writer = new StreamWriter("ScannedBleDeviceModelFile.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                
                csv.WriteRecords(ListPB);
            }
        }
        public static void ListOfMissingDevices(List<BleDeviceModel> CheckList,List<SensorModel> list)
        {
            var ListPS = new List<PartialSensorModel>();
            foreach (var val in list)
            {
                if(CheckList.FindIndex(x=> x.Mac.Equals(val.Mac,StringComparison.OrdinalIgnoreCase))==-1)
                {
                    PartialSensorModel PS = new PartialSensorModel();
                    PS.Mac = val.Mac;
                    PS.SerialNumber = val.SerialNumber;
                    ListPS.Add(PS);
                }
            }
            using (var writer = new StreamWriter("MissingSensorModelFile.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                csv.WriteRecords(ListPS);
            }
        }
    }
}
