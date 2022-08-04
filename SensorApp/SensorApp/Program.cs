using Common;
using Common.ListModelsToModelCsv;
using Newtonsoft.Json;
using SensorApp;
using SensorApp.Lists;
using SensorApp.Services;
using SensorApp.Servis;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Press any key to proced...");
Console.ReadKey();
Console.ForegroundColor = ConsoleColor.White;
string BlescanParametersSerialized = File.ReadAllText(@"BlescanConfig.json");
BlescanParameters blescan = JsonConvert.DeserializeObject<BlescanParameters>(BlescanParametersSerialized);
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Start");
//string name;
//name = Console.ReadLine();
//string filename = name;
var listSensor = new DatabaseSensorManager();
listSensor.ReadFromFile(blescan.NameOfCsvFile);
//Console.WriteLine(listSensor.SensorList.Count);
for (int i = 1; i <= blescan.NumberOfScansToDo; i++)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Sudo command inicialize for {i} time!");
    string command = $"sudo blescan -i {blescan.hci}";
    Console.WriteLine(command);
    var com = LinuxCommand.SystemCommand(command);
    var listBluetooth = new ScannsedSensorManager(new BlePhrase());
    Console.WriteLine("Making list inicialize");
    listBluetooth.ReadBlue(com);
    Console.WriteLine("Reading list inicialize");
    Console.ForegroundColor = ConsoleColor.Green;
    GlobalList.ToAdd(listBluetooth.BluetoothList, listSensor.SensorList);
    Console.WriteLine("Global list Count: " + GlobalList.R().Count);
}
//SensorModelHelper.DisplaySensorList(GlobalList.R());
ListOfSpecificModelToCsv.ListOfBleDeviceModelToCsvFile(GlobalList.R(), listSensor.SensorList);
ListOfSpecificModelToCsv.ListOfMissingDevices(GlobalList.R(), listSensor.SensorList);
Console.WriteLine($"Finish with GlobalList Count: {GlobalList.R().Count}");
Console.ForegroundColor = ConsoleColor.White;
if (GlobalList.R().Count != 0)
{
    int MedianRssi = CheckingRssiMedian.ChceckMedianRssi();
    double StandardOffset = 1 + double.Parse(blescan.StandardOffset.Substring(0, blescan.StandardOffset.Length - 1)) / 100;
    SensorModelHelper.DisplayRssiWithWrongOffset(MedianRssi * StandardOffset, listSensor.SensorList);
    //Console.WriteLine(MedianRssi + " * " + StandardOffset + " = " + MedianRssi * StandardOffset);
}


//Brak dalszych modyfikacji.
