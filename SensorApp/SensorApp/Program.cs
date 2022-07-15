using SensorApp.Lists;

string name;
name = Console.ReadLine();
string filename = name;
var listSensor = new ListSensor();
listSensor.ReadFromFile(filename);

