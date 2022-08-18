using Common.Modeles;

namespace SensorApp.Services
{
    public class CheckingRssi
    {
        public static int ChceckMedianRssi(IEnumerable<BleDeviceModel> list)
        {
            List<int> rssi = new List<int>();
            foreach (var val in list)
            {
                rssi.Add(val.Mediana);
            }
            rssi.Sort();
            return rssi[rssi.Count / 2];
        }
        public static double CheckingAvregeRssi(IEnumerable<BleDeviceModel> list)
        {
            List<int> rssi = new List<int>();
            foreach(var value in list)
            {
                rssi.AddRange(value.DBm);
            }
            return rssi.Average();
        }
    }
}
