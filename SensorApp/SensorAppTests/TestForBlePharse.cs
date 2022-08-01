using SensorApp.Lists;
using Common.Modeles;
using SensorApp.Servis;
using System.Linq;

namespace SensorAppTests
{
    public class TestForBlePhrase
    {
        [Theory]
        [InlineData("Alfa beta (new): 7c:fd:6b:e4:54:5a -99000 dBm Manufacturer: <9034928395>", "7c:fd:6b:e4:54:5a -99000 ", "9034928395")]
        public void BlePhrase_SchouldWork(string input, string expected, string AdvForTest)
        {
            //Arnage
            IBlePhrase blePhrase = new BlePhrase();
            List<byte> tmpE = Enumerable.Range(0, AdvForTest.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(AdvForTest.Substring(x, 2), 16))
                .ToList();
            foreach (var val in tmpE)
            {
                expected += val.ToString() + ",";
            }
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input,1);
            string tmpA = "";
            foreach (var val in list.ElementAt(0).Manufacture)
            {
                tmpA += val.ToString() + ",";
            }
            string actual = list.ElementAt(0).Mac + " " + list.ElementAt(0).DBm[0] + " " + tmpA;

            //Asset
            Assert.Equal(expected, actual);

        }
        [Theory]
        [InlineData("", 0)]
        public void BlePhrase_SchouldNotWork(string input, int expected)
        {
            //Arange
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input,0);
            int actual = list.Count();
            //Asset
            Assert.Equal(expected, actual);
        }
        /*[Theory]
        [InlineData(@" Device (new): 60:77:71:60:ce:46 (public), -76 dBm
        Flags: < 06 >
        Manufacturer: <020df7e000c000aa770000af000005>.
    Device (new): 80:6f:b0: ab:40:37(public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000a2000000>.
    Device (new): 60:77:71:60:37:53 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab000000af000000>.
    Device (new): 60:77:71:5f:d7:c7(public), -95 dBm
        Flags: <06>
        Manufacturer: <020df0e072a000ab00000099000000>.
    Device (new): 60:77:71:60:49:48 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab010000a2000000>.
    Device (new): 60:77:71:60:48:73 (public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac010000ac000000>.
    Device (new): 60:77:71:da:fe:32 (public), -89 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000b8000000>.
        ",7)]
        public void SchouldReturnCorrectNumberOfSensors(string input,int expected)
        {
            //Arnage
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input);
            int actual = list.Count();
            //Asset
            Assert.Equal(expected, actual);

        }*/
        [Theory]
        [InlineData(@" Device (new): 60:77:71:60:ce:46 (public), -76 dBm
        Flags: < 06 >
        Manufacturer: <020df7e000c000aa770000af000005> Device (new): 80:6f:b0: ab:40:37 (public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000a2000000> Device (new): 60:77:71:60:37:53 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab000000af000000> Device (new): 60:77:71:5f:d7:c7 (public), -95 dBm
        Flags: <06> Manufacturer: <020df0e072a000ab00000099000000> Device (new): 60:77:71:60:49:48 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab010000a2000000> Device (new): 60:77:71:60:48:73 (public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac010000ac000000> Device (new): 60:77:71:da:fe:32 (public), -89 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000b8000000>", 7)]
        public void SchouldReturnCorrectNumberOfSensors(string input, int expected)
        {
            //Arnage
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input,7);
            int actual = list.Count();
            //Asset
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(@" Device (new): 60:77:71:60:ce:46 (public), -76 dBm
        Flags: < 06 >
        Manufacturer: <020df7e000c000aa770000af000005> Device (update): 60:77:71:60:ce:46 (public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000a2000000> Device (update): 60:77:71:60:ce:46 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab000000af000000> Device (update): 60:77:71:60:ce:46 (public), -95 dBm
        Flags: <06> Manufacturer: <020df0e072a000ab00000099000000>. Device (new):60:77:71:60:ce:46 (public), -92 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ab010000a2000000> Device (update): 60:77:71:60:ce:46 (public), -90 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac010000ac000000> Device (update): 60:77:71:60:ce:46 (public), -89 dBm
        Flags: <06>
        Manufacturer: <020dffe072a000ac000000b8000000>", 7)]
        public void SchouldReturnCorrectRssiCount(string input,int expected)
        {
            //Arnage
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input,7);
            IEnumerable<int> actual_value = list.ElementAt(0).DBm;
            int actual = actual_value.Count();
            //Asset
            Assert.Equal(expected, actual);
        }
    }
}