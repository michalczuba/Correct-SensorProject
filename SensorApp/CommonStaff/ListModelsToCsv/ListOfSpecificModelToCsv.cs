using Common.Modeles;
using CsvHelper;
using System.Globalization;
namespace Common.ListModelsToModelCsv
{
    public class ListOfSpecificModelToCsv
    {
        private class PartialBleDiviceModel
        {
            public string? SerialNumber { get; set; }
            public string? Mac { get; set; }
            public int? Rssi { get; set; }

            public string? WarningOrMissing { get; set; }
            public string? WarningAdv { get; set; }
            public string? Pagaes_per { get; set; }
        }
        private class PackagesStatistic
        {
            public double SumOfPackagesPercent { get; set; }
            public int NumberOfDevicesScanned { get; set; }
        }

        public static void ListOfBleDeviceModelToCsvFile(IEnumerable<BleDeviceModel> list, List<SensorModel> CsvFile, double Rw, double AdvUp, double AdvDown, int IndexAdv, double pakages)
        {
            var ListPB = new List<PartialBleDiviceModel>();
            List<BleDeviceModel> TmpList = list.ToList();
            ListPB = CreateAListToSave(CsvFile, TmpList, Rw, AdvUp, AdvDown, IndexAdv, pakages);
            //Uncoment line below to see avrege package per
            //Console.WriteLine("Avrega PP: " + Avrege_PP.ToString("0.##") + "%");
            using (var writer = new StreamWriter("ScannedBleDeviceModelFile.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(ListPB);
            }
        }
        private static PartialBleDiviceModel CreataPartialDevice(SensorModel val, List<BleDeviceModel> TemporaryListOfBleDeviceModel, int index, double Rw, double AdvUp, double AdvDown, int IndexAdv, double packages)
        {
            PartialBleDiviceModel partialBleDeviceModel = new PartialBleDiviceModel();
            if (index == -1)
            {
                partialBleDeviceModel.Mac = val.Mac;
                partialBleDeviceModel.SerialNumber = val.SerialNumber;
                partialBleDeviceModel.Rssi = null;
                partialBleDeviceModel.WarningOrMissing = "Missing";
            }
            else
            {
                //Calulating percent of package 
                double check = (TemporaryListOfBleDeviceModel[index].DBm.Count / packages) * 100;
                partialBleDeviceModel.Pagaes_per = check.ToString("0.##") + "%";
                partialBleDeviceModel.Mac = val.Mac;
                partialBleDeviceModel.SerialNumber = val.SerialNumber;
                partialBleDeviceModel.Rssi = TemporaryListOfBleDeviceModel[index].Avrege;
                if (partialBleDeviceModel.Rssi < Rw)
                    partialBleDeviceModel.WarningOrMissing = "Warning";
                else
                    partialBleDeviceModel.WarningOrMissing = "";

                if (TemporaryListOfBleDeviceModel[index].Manufacture.Count() >= IndexAdv)
                {
                    if (TemporaryListOfBleDeviceModel[index].Manufacture.ElementAt(IndexAdv - 1) > AdvUp || TemporaryListOfBleDeviceModel[index].Manufacture.ElementAt(IndexAdv - 1) < AdvDown)
                    {
                        partialBleDeviceModel.WarningAdv = "WarningAdv";
                    }
                }
                else
                {
                    partialBleDeviceModel.WarningAdv = "WarningAdv";
                }


            }
            return partialBleDeviceModel;
        }
        private static List<PartialBleDiviceModel> CreateAListToSave(List<SensorModel> CsvFile, List<BleDeviceModel> TemporaryListOfBleDeviceModel, double Rw, double AdvUp, double AdvDown, int IndexAdv, double packages)
        {
            List<PartialBleDiviceModel> ListOfPartialDeviceModel = new List<PartialBleDiviceModel>();
            PackagesStatistic AvregePackagesPercent = new PackagesStatistic();
            foreach (var val in CsvFile)
            {
                int index = TemporaryListOfBleDeviceModel.FindIndex(x => x.Mac.Equals(val.Mac, StringComparison.OrdinalIgnoreCase));
                ListOfPartialDeviceModel.Add(CreataPartialDevice(val, TemporaryListOfBleDeviceModel, index, Rw, AdvUp, AdvDown, IndexAdv, packages));
                if (index != -1)
                {
                    double tmp = double.Parse(ListOfPartialDeviceModel[ListOfPartialDeviceModel.Count - 1].Pagaes_per.Substring(0, ListOfPartialDeviceModel[ListOfPartialDeviceModel.Count - 1].Pagaes_per.Length - 1)) / 100;
                    AvregePackagesPercent.SumOfPackagesPercent += tmp;
                    AvregePackagesPercent.NumberOfDevicesScanned++;
                }
            }
            WriteAvregePackagesPercent((AvregePackagesPercent.SumOfPackagesPercent / AvregePackagesPercent.NumberOfDevicesScanned)*100);
            return ListOfPartialDeviceModel;
        }
        private static void WriteAvregePackagesPercent(double avrege)
        {
            Console.WriteLine("Avrega PP: " + avrege.ToString("0.##") + "%");
        }
    }
}
