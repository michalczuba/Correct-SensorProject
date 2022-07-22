using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HexStringToByteList
    {
        public static List<Byte> HexToByteList(string HexString)
        {
            return Enumerable.Range(0,HexString.Length)
                .Where(x => x%2 == 0)
                .Select(x => Convert.ToByte(HexString.Substring(x,2),16))
                .ToList();
        }
    }
}
