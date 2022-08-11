namespace SensorApp
{
    public class BlescanParameters
    {
        public string hci { get; set; }
        public int NumberOfScansToDo { get; set; }
        public string StandardOffsetRSSI { get; set; }
        public string StandardOffsetADV { get; set; }
        public string NameOfCsvFile { get; set; }
        public int Index { get; set; }
        public double PackagesPerS { get; set; }
    }
}
