using System.Text.RegularExpressions;

namespace Common
{
    public class StringIsMac
    {
        public StringIsMac()
        {

        }
        public void IsMac(string mac)
        {
            mac = mac.Replace(" ", "").Replace(":", "").Replace("-", "");
            Regex r = new Regex("^[a-fA-F0-9]{12}$");
            if (!r.IsMatch(mac))
            {
                Console.WriteLine("Detected wrong Mac.\n");
                Console.WriteLine("Reboot Program.\n");
                Environment.Exit(0);
            }
        }
    }
}
