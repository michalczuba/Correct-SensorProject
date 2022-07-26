using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FilePath
    {
        public static string PathToFile(string name)
        {
            string fullPath = Path.GetFullPath(name); //f.FullName;//Path.GetFullPath(@"SensorList.csv");

            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File of that name dosen't exist or it's not in the same catlog as program.\n");
                Console.WriteLine("Reboot Program.\n");
                Environment.Exit(0);
            }
            return fullPath;
        }
    }
}
