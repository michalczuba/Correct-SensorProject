namespace SensorApp.Services
{
    public class CheckingRssiMedian
    {
        public static int ChceckMedianRssi()
        {
            List<int> rssi = new List<int>();
            foreach (var val in GlobalList.R())
            {
                rssi.Add(val.Mediana);
            }
            rssi.Sort();
            return rssi[rssi.Count / 2];
        }
    }
}
