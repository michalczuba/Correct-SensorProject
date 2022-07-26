using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SensorApp.Lists;
using Common.Modules;
namespace UnitTest
{
    public class BlePhraseTest
    {
        public void BlePhrase_ShuldWork(string line)
        {
            ListBluetooth.ReadBlue(line);
        }
    }
}
