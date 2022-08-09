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
            public int? Rssi { get; set; }

            public string WarningOrMissing { get; set; }
            public string WarningAdv { get; set; }
        }
        public static void ListOfBleDeviceModelToCsvFile(IEnumerable<BleDeviceModel> list, List<SensorModel> CsvFile, double Rw,double AdvUp,double AdvDown,int IndexAdv)
        {
            var ListPB = new List<PartialBleDiviceModel>();
            List<BleDeviceModel> TmpList = list.ToList();
            foreach (var val in CsvFile)
            {
                PartialBleDiviceModel PB = new PartialBleDiviceModel();
                int index = TmpList.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                if (index == -1)
                {
                    PB.Mac = val.Mac;
                    PB.SerialNumber = val.SerialNumber;
                    PB.Rssi = null;
                    PB.WarningOrMissing = "Missing";
                }
                else
                {
                    PB.Mac = val.Mac;
                    PB.SerialNumber = val.SerialNumber;
                    PB.Rssi = TmpList[index].Avrege;
                    if (PB.Rssi < Rw)
                        PB.WarningOrMissing = "Warning";
                    else
                        PB.WarningOrMissing = "";

                    if(TmpList[index].Manufacture.Count()>= IndexAdv)
                    {
                        if (TmpList[index].Manufacture.ElementAt(IndexAdv - 1) > AdvUp || TmpList[index].Manufacture.ElementAt(IndexAdv - 1) < AdvDown)
                        {
                            PB.WarningAdv = "WarningAdv";
                        }
                    }
                    else
                    {
                        PB.WarningAdv = "WarningAdv";
                    }

                }


                ListPB.Add(PB);

            }
            using (var writer = new StreamWriter("ScannedBleDeviceModelFile.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ListPB);
            }
        }

    }
}
