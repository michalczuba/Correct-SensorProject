using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
using CsvHelper;
using CsvHelper.TypeConversion;
namespace Common.ListModelsToModelCsv
{
    public class ListOfBleDeviceModelToCsv
    {
        public class PartialBleDiviceModel
        {
            public string mac { get; set; }
            public int rssi { get; set; }
            //public int man { get; set; } 
        }
        public static void ListOfBleDeviceModelToCsvFile(IEnumerable<BleDeviceModel> list)
        {
            

            var ListPB = new List<PartialBleDiviceModel>();
            foreach (var val in list)
            {
                PartialBleDiviceModel PB = new PartialBleDiviceModel();
                PB.mac = val.Mac;
                PB.rssi = val.Mediana;
                //PB.man = 0;
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
