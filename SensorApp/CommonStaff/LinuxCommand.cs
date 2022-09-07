using System.Diagnostics;
namespace Common
{
    public class LinuxCommand
    {
        private static string MakeInfluxCommand(string command)
        {
            string Ixcommand =$"influx -execute '{command}'";
            return Ixcommand;
        }
        private static string MakeInfluxCommandDelete(string command,string database)
        {
            string InfluxCommand = $"influx -execute "+'"'+command+'"'+" -database="+'"'+database+'"';
            return InfluxCommand;
        }
        public static string SystemCommand(string command)//this will start linux command and return what system will write
        {
            command = command.Replace("\"", "\"\"");
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "/bin/bash",
                    //Arguments = "-c \"" + command + "\"",
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true

                }
            };
            //proc.Start();
            //proc.WaitForExit();
            //return proc.StandardOutput.ReadToEnd();
            proc.Start();
            //proc.BeginOutputReadLine();
            proc.WaitForExit(3000);

            return proc.StandardOutput.ReadToEnd();
        }
        public static void SystemCommandVoid(string command)//this will start linux command and return what system will write
        {
            command = command.Replace("\"", "\"\"");
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "/bin/bash",
                    //Arguments = "-c \"" + command + "\"",
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true

                }
            };
            //proc.Start();
            //proc.WaitForExit();
            //return proc.StandardOutput.ReadToEnd();
            proc.Start();
            //proc.BeginOutputReadLine();
            proc.WaitForExit(3000);

        }
        public static string InfluxCommand(string command)//this will start linux command and return what system will write
        {
            command = MakeInfluxCommand(command);
            command = command.Replace("\"", "\"\"");
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "/bin/bash",
                    //Arguments = "-c \"" + command + "\"",
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true

                }
            };
            //proc.Start();
            //proc.WaitForExit();
            //return proc.StandardOutput.ReadToEnd();
            proc.Start();
            //proc.BeginOutputReadLine();
            proc.WaitForExit(3000);

            return proc.StandardOutput.ReadToEnd();
        }
        //influx -execute "DELETE FROM \"60:77:71:5D:DF:27\" WHERE Info='BAZA_SENSORÓW.csv;;;'" -database="TryInflux"
        public static string InfluxCommandVoid(string command,string databse)//this will start linux command and return what system will write
        {
            //command = MakeInfluxCommandDelete(command,databse);
            //command = command.Replace("\"", "\"\"");
            //Console.WriteLine(command);
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = "/bin/bash",
                    //Arguments = "-c \"" + command + "\"",
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true

                }
            };
            //proc.Start();
            //proc.WaitForExit();
            //return proc.StandardOutput.ReadToEnd();
            proc.Start();
            //proc.BeginOutputReadLine();
            proc.WaitForExit(3000);

            return proc.StandardOutput.ReadToEnd();
        }
        
    }
}