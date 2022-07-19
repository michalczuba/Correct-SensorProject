using SensorApp.Lists;
using CommonStaff;
string name;
name = Console.ReadLine();
string filename = name;
var listSensor = new ListSensor();
listSensor.ReadFromFile(filename);
var com = LinuxCommand.SystemCommand("sudo blescan");
var listBluetooth = new ListBluetooth();
listBluetooth.ReadBlue(com);
//Brak dalszych modyfikacji.
        