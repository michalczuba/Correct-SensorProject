using SensorApp.Lists;
using Common;
string name;
name = Console.ReadLine();
string filename = name;
var listSensor = new DatabaseSensorManager();
listSensor.ReadFromFile(filename);
var com = LinuxCommand.SystemCommand("sudo blescan");
var listBluetooth = new ScannsedSensorManager();
listBluetooth.ReadBlue(com);
//Brak dalszych modyfikacji.
        