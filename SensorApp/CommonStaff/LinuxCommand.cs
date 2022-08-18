using System.Diagnostics;
namespace Common
{
    public class LinuxCommand
    {
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
            proc.WaitForExit(5000);

            return proc.StandardOutput.ReadToEnd();
        }
    }
}