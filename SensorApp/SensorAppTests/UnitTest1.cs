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
            string expected = "MAC -99000 <9034928395>";
            //Act
            List<BleDeviceModel> list = new List<BleDeviceModel>();
            list = BlePhrase.PhraseBlue(input);
            string actual = list[0].Mac + " " + list[0].DBm + " " + list[0].Manufacture;
            
            //Asset
            Assert.Equal(expected,actual);
        }
    }
}