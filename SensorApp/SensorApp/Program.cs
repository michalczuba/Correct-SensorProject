using Common;
using Common.ListModelsToModelCsv;
using Newtonsoft.Json;
using SensorApp;
using SensorApp.Lists;
using SensorApp.Services;
using SensorApp.Servis;
using System.Diagnostics;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Press any key to proced...");
Console.ReadKey();
Console.ForegroundColor = ConsoleColor.White;
string BlescanParametersSerialized = File.ReadAllText(@"BlescanConfig.json");
BlescanParameters blescan = JsonConvert.DeserializeObject<BlescanParameters>(BlescanParametersSerialized);
Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(blescan.PackagesPerS);
Console.WriteLine("Start");
//string name;
//name = Console.ReadLine();
//string filename = name;
Stopwatch stopwatch = new Stopwatch();
var listSensor = new DatabaseSensorManager();
listSensor.ReadFromFile(blescan.NameOfCsvFile);
//Console.WriteLine(listSensor.SensorList.Count);
for (int i = 1; i <= blescan.NumberOfScansToDo; i++)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Sudo command inicialize for {i} time!");
    string command = $"sudo blescan -i {blescan.hci}";
    
    Console.WriteLine(command);
    stopwatch.Start();
    var com = LinuxCommand.SystemCommand(command);
    stopwatch.Stop();
    var listBluetooth = new ScannsedSensorManager(new BlePhrase());
    Console.WriteLine("Making list inicialize");
    listBluetooth.ReadBlue(com);
    Console.WriteLine("Reading list inicialize");
    Console.ForegroundColor = ConsoleColor.Green;
    GlobalList.ToAdd(listBluetooth.BluetoothList, listSensor.SensorList);
    Console.WriteLine("Global list Count: " + GlobalList.R().Count);
}
//SensorModelHelper.DisplaySensorList(GlobalList.R());

Console.WriteLine($"Finish with GlobalList Count: {GlobalList.R().Count}");
Console.ForegroundColor = ConsoleColor.White;

double all_sensors = listSensor.SensorList.Count;
double good_sensors = GlobalList.R().Count;
double warning_sensors = 0;
double missing_sensors = 0;
double warningAdv = 0;
int index = blescan.Index;



int MedianRssi = CheckingRssi.ChceckMedianRssi(GlobalList.R());
double AvregeRssi = CheckingRssi.CheckingAvregeRssi(GlobalList.R());
long AvregeAdv = GlobalList.ChceckAvregeAdvOnDefineIndex(index);
double StandardOffset = 1 + double.Parse(blescan.StandardOffsetRSSI.Substring(0, blescan.StandardOffsetRSSI.Length - 1)) / 100;
double StandardOffsetUp = 1 + double.Parse(blescan.StandardOffsetADV.Substring(0, blescan.StandardOffsetADV.Length - 1)) / 100;
double StandardOffsetDown = 1 - double.Parse(blescan.StandardOffsetADV.Substring(0, blescan.StandardOffsetADV.Length - 1)) / 100;
warning_sensors = SensorModelHelper.DisplayRssiWithWrongOffset(AvregeRssi * StandardOffset, listSensor.SensorList);
warningAdv=SensorModelHelper.DisplayAdvWithWrongOffset(AvregeAdv * StandardOffsetUp, AvregeAdv * StandardOffsetDown,index,listSensor.SensorList);
//Console.WriteLine(MedianRssi + " * " + StandardOffset + " = " + MedianRssi * StandardOffset);
missing_sensors = SensorModelHelper.DisplaySensorListMissing(listSensor.SensorList);
if(warningAdv>warning_sensors)
good_sensors = good_sensors - warningAdv;
else
good_sensors = (good_sensors - warning_sensors);
if (all_sensors != 0)
{
    good_sensors /= all_sensors;
    warning_sensors /= all_sensors;
    missing_sensors /= all_sensors;
    warningAdv /= all_sensors;
}
good_sensors *= 100;
warning_sensors *= 100;
missing_sensors *= 100;
warningAdv *= 100;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Percent of good sensors {good_sensors.ToString("0.##")}%");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Percent of warning sensors {warning_sensors.ToString("0.##")}%");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"Percent of missing sensors {missing_sensors.ToString("0.##")}%");
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"Percent of warning adv. sensors {warningAdv.ToString("0.##")}%");
Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("Avrage:");
//SensorModelHelper.DisplayRssiWithWrongOffset(AvregeRssi* StandardOffset, listSensor.SensorList);
TimeSpan timeSpan;
while (true)
{
    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine("\t Menu what you want to do: ");
    Console.WriteLine("\t Press R - rescan all devices");
    Console.WriteLine("\t Press E - End program and save resalts to csv file");
    Console.WriteLine("--------------------------------------------------------------------");
    string check = Console.ReadLine();
    if (check.Equals("e", StringComparison.OrdinalIgnoreCase))
    {
        timeSpan = stopwatch.Elapsed;
        break;
    }
    if (check.Equals("r", StringComparison.OrdinalIgnoreCase))
    {
        stopwatch.Reset();
        GlobalList.OneRSSI(unchecked((int)AvregeRssi));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Rescan");
        for (int i = 1; i <= blescan.NumberOfScansToDo; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Sudo command inicialize for {i} time!");
            string command = $"sudo blescan -i {blescan.hci}";
            
            Console.WriteLine(command);
            stopwatch.Start();
            var com = LinuxCommand.SystemCommand(command);
            stopwatch.Stop();
            var listBluetooth = new ScannsedSensorManager(new BlePhrase());
            Console.WriteLine("Making list inicialize");
            listBluetooth.ReadBlue(com);
            Console.WriteLine("Reading list inicialize");
            Console.ForegroundColor = ConsoleColor.Green;
            GlobalList.ToAdd(listBluetooth.BluetoothList, listSensor.SensorList);
            Console.WriteLine("Global list Count: " + GlobalList.R().Count);
        }
        //SensorModelHelper.DisplaySensorList(GlobalList.R());

        Console.WriteLine($"Finish with GlobalList Count: {GlobalList.R().Count}");
        Console.ForegroundColor = ConsoleColor.White;
        //all_sensors = GlobalList.R().Count;
        good_sensors = GlobalList.R().Count;
        MedianRssi = CheckingRssi.ChceckMedianRssi(GlobalList.R());
        AvregeRssi = CheckingRssi.CheckingAvregeRssi(GlobalList.R());
        AvregeAdv = GlobalList.ChceckAvregeAdvOnDefineIndex(index);
        SensorModelHelper.DisplayAdvWithWrongOffset(AvregeAdv * StandardOffsetUp, AvregeAdv * StandardOffsetDown, index, listSensor.SensorList);
        warning_sensors = SensorModelHelper.DisplayRssiWithWrongOffset(AvregeRssi * StandardOffset, listSensor.SensorList);
        //Console.WriteLine(MedianRssi + " * " + StandardOffset + " = " + MedianRssi * StandardOffset);
        missing_sensors = SensorModelHelper.DisplaySensorListMissing(listSensor.SensorList);
        if (warningAdv > warning_sensors)
            good_sensors = (good_sensors - warningAdv) ;
        else
            good_sensors = (good_sensors - warning_sensors);
        if (all_sensors != 0)
        {
            good_sensors /= all_sensors;
            warning_sensors /= all_sensors;
            missing_sensors /= all_sensors;
            warningAdv /= all_sensors;
        }
        good_sensors *= 100;
        warning_sensors *= 100;
        missing_sensors *= 100;
        warningAdv *= 100;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Percent of good sensors {good_sensors.ToString("0.##")}%");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Percent of warning sensors {warning_sensors.ToString("0.##")}%");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Percent of missing sensors {missing_sensors.ToString("0.##")}%");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Percent of warning adv. sensors {warningAdv.ToString("0.##")}%");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.WriteLine("Wrong key. Try again!");
    }

}
//Uncoment line below to see avrege rssi
Console.WriteLine("Avrege Rssi: " + AvregeRssi);
double seconds_of_work_and_pakages = blescan.PackagesPerS*(timeSpan.Seconds+timeSpan.Minutes*60);
//Console.WriteLine($"Time of scan and x pages: {blescan.PackagesPerS} pack/s * {timeSpan.TotalSeconds} = {seconds_of_work_and_pakages}");
ListOfSpecificModelToCsv.ListOfBleDeviceModelToCsvFile(GlobalList.R(), listSensor.SensorList, AvregeRssi * StandardOffset,AvregeAdv*StandardOffsetUp,AvregeAdv*StandardOffsetDown,index, seconds_of_work_and_pakages);


//Brak dalszych modyfikacji.
