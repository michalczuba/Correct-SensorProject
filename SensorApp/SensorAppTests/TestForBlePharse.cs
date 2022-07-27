using SensorApp.Lists;
using Common.Modeles;
using SensorApp.Servis;
namespace SensorAppTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Alfa beta (new): MAC -99000 dBm Manufacturer: <9034928395>")]
        public void BlePhrase_SchouldWork(string input)
        {
            //Arnage
            string expected = "MAC -99000 ";
            string y = "9034928395";
            List<byte> tmpE = Enumerable.Range(0,y.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(y.Substring(x, 2), 16))
                .ToList();
            foreach(var val in tmpE)
            {
                expected += val.ToString()+",";
            }
            //Act
            List<BleDeviceModel> list = new List<BleDeviceModel>();
            list = BlePhrase.PhraseBlue(input);
            string tmpA = "";
            foreach(var val in list[0].Manufacture)
            {
                tmpA +=val.ToString()+",";
            }
            string actual = list[0].Mac + " " + list[0].DBm + " " +tmpA;
            
            //Asset
            Assert.Equal(expected,actual);
        }
    }
}