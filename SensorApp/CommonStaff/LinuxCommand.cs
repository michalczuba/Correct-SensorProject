using System.Diagnostics;
namespace Common
{
    public class LinuxCommand
    {
        private static string MakeInfluxCommand(string command)
        {
            string Ixcommand = "influx -execute '";
            Ixcommand += command;
            Ixcommand += "'";
            return Ixcommand;
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
        public static void InfluxCommandVoid(string command)//this will start linux command and return what system will write
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

            
        }
        
    }
}