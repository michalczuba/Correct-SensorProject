using Common.Modeles;
namespace SensorApp.Services
{
    static class GlobalList
    {
        static List<BleDeviceModel> _list;
        static GlobalList()
        {
            _list = new List<BleDeviceModel>();
        }
        public static void ToAdd(IEnumerable<BleDeviceModel> list, List<SensorModel> CheckList)
        {

            //Console.WriteLine($"Comapre list count:{list.Count()} with Checklist count: {CheckList.Count}");
            //string vart = list.First().Mac;
            //Console.WriteLine("|"+list.First().Mac+ "| Size:" + list.First().Mac.Length);
            //Console.WriteLine("|" + vart + "| Size:" + vart.Length);
            //string[] tmp = vart.Split('m',' ','\n');
            //foreach (var lol in tmp)
            //Console.WriteLine($"|{lol}|");
            //Console.WriteLine("|"+CheckList.First().Mac + "| Size:" + CheckList.First().Mac.Length);

            foreach (var model in list)
            {
                if (CheckList.FindIndex(x => x.Mac.Equals(model.Mac, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    int index = _list.FindIndex(x => x.Mac == model.Mac);
                    if (index != -1)
                    {
                        foreach (var val in model.DBm)
                        {
                            _list[index].AddToRSSI(val);
                        }
                    }
                    else
                    {
                        _list.Add(model);
                    }
                }

            }

        }
        public static List<BleDeviceModel> R()
        {
            return _list;
        }
    }
}
