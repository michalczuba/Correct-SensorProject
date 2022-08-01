using SensorApp.Lists;
using Common;
using SensorApp.Services;
using SensorApp.Servis;
using SensorApp;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

//string name;
//name = Console.ReadLine();
//string filename = name;
//var listSensor = new DatabaseSensorManager();
//listSensor.ReadFromFile(filename);
string filepath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\HciSettings.json";
string HciSerialized = File.ReadAllText(@"HciConfig.json");
HCI HCI = JsonConvert.DeserializeObject<HCI>(HciSerialized);
Console.WriteLine("Sudo command inicialize");
string command = $"sudo blescan -i {HCI.hci}";
Console.WriteLine(command);
var com = LinuxCommand.SystemCommand(command);
var listBluetooth = new ScannsedSensorManager(new BlePhrase());
Console.WriteLine("Making list inicialize");
listBluetooth.ReadBlue(com);
Console.WriteLine("Reading list inicialize");
SensorModelHelper.DisplaySensorList(listBluetooth.BluetoothList);
//Brak dalszych modyfikacji.
