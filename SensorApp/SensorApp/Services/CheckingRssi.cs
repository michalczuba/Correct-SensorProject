namespace SensorApp.Services
{
    public class CheckingRssi
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
        public static long CheckingAvregeRssi()
        {
            List<int> rssi = new List<int>();
            long Big = 0;
            foreach(var value in GlobalList.R())
            {
                foreach(var val in value.DBm)
                {
                    Big += val;
                    rssi.Add(val);
                }
            }
            return Big/rssi.Count();
        }
    }
}
