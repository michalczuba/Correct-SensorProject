using SensorApp.Lists;
using Common;
using SensorApp.Services;
using SensorApp.Servis;
//string name;
//name = Console.ReadLine();
//string filename = name;
//var listSensor = new DatabaseSensorManager();
//listSensor.ReadFromFile(filename);
Console.WriteLine("Sudo command inicialize");
var com = LinuxCommand.SystemCommand("sudo blescan -i 1");
var listBluetooth = new ScannsedSensorManager(new BlePhrase());
Console.WriteLine("Making list inicialize");
listBluetooth.ReadBlue(com);
Console.WriteLine("Reading list inicialize");
SensorModelHelper.DisplaySensorList(listBluetooth.BluetoothList);
//Brak dalszych modyfikacji.
        