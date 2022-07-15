using System.Diagnostics;
namespace CommonStaff
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
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            proc.WaitForExit();
            return proc.StandardOutput.ReadToEnd();
        }
    }
}