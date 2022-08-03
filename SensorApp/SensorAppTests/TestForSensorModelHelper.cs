using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorApp.Lists;
using Common.Modeles;
using SensorApp.Servis;
namespace SensorAppTests
{
    public class TestForSensorModelHelper
    {
        [Theory]
        [InlineData("Alfa beta (new): 60:77:71:60:f3:04 -99000 dBm Manufacturer: <9034928395>", "60:77:71:60:f3:04 A22044066 -99000 1")]
        public void BlePhrase_SchouldWork(string input, string expected)
        {
            ////Arnage
            //IBlePhrase blePhrase = new BlePhrase();
            ////Act
            //IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            //list = blePhrase.PhraseBlue(input);
            //if()

            ////Asset
            //Assert.Equal(expected, actual);

        }
    }
}
