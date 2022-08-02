using SensorApp.Lists;
using Common;
using SensorApp.Services;
using SensorApp.Servis;
using SensorApp;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Common.ListModelsToModelCsv;
//string name;
//name = Console.ReadLine();
//string filename = name;
//var listSensor = new DatabaseSensorManager();
//listSensor.ReadFromFile(filename);

string filepath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\HciSettings.json";
string HciSerialized = File.ReadAllText(@"HciConfig.json");
BlescanParameters HCI = JsonConvert.DeserializeObject<BlescanParameters>(HciSerialized);
Console.WriteLine("Start");

for (int i = 0; i < HCI.NumberOfScansToDo; i++)
{
    Console.WriteLine($"Sudo command inicialize for {i} time!");
    string command = $"sudo blescan -i {HCI.hci}";
    Console.WriteLine(command);
    var com = LinuxCommand.SystemCommand(command);
    var listBluetooth = new ScannsedSensorManager(new BlePhrase());
    Console.WriteLine("Making list inicialize");
    listBluetooth.ReadBlue(com);
    Console.WriteLine("Reading list inicialize");
    GlobalList.ToAdd(listBluetooth.BluetoothList);
    Console.WriteLine("Global list Count: " + GlobalList.R().Count);
}
//SensorModelHelper.DisplaySensorList(GlobalList.R());
ListOfBleDeviceModelToCsv.ListOfBleDeviceModelToCsvFile(GlobalList.R());
Console.WriteLine("Finish " + GlobalList.R().Count);
int MedianRssi = CheckingRssiMedian.ChceckMedianRssi();
double StandardOffset = 1 + double.Parse(HCI.StandardOffset.Substring(0, HCI.StandardOffset.Length - 1)) / 100;
SensorModelHelper.DisplayRssiWithWrongOffset(MedianRssi * StandardOffset);
Console.WriteLine(MedianRssi+" * "+StandardOffset+" = "+MedianRssi * StandardOffset);
//Brak dalszych modyfikacji.
