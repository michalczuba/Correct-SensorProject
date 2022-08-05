namespace Common.Modeles
{
    public class BleDeviceModel
    {
        public BleDeviceModel(string mac, int dBm, IEnumerable<byte> manufacture)
        {
            DBm = new List<int>();
            Mac = mac;
            DBm.Add(dBm);
            Manufacture = manufacture;
            Mediana = dBm;
        }
        public void AddToRSSI(int dBm)
        {
            DBm.Add(dBm);
            DBm.Sort();
            Mediana = DBm[DBm.Count / 2];
        }
        public void SetRSSITo(int dBm)
        {
            DBm.Clear();
            DBm.Add(dBm);
            Mediana = dBm;
        }
        public string Mac { private set; get; }
        public List<int> DBm { private set; get; }
        public IEnumerable<byte> Manufacture { private set; get; }
        public int Mediana { private set; get; }
    }
}
