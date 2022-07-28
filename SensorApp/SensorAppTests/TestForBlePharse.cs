using SensorApp.Lists;
using Common.Modeles;
using SensorApp.Servis;
namespace SensorAppTests
{
    public class TestForBlePhrase
    {
        [Theory]
        [InlineData("Alfa beta (new): 7c:fd:6b:e4:54:5a -99000 dBm Manufacturer: <9034928395>.", "7c:fd:6b:e4:54:5a -99000 ", "9034928395")]
        public void BlePhrase_SchouldWork(string input, string expected,string AdvForTest)
        {
            //Arnage
            IBlePhrase blePhrase = new BlePhrase();  
            List<byte> tmpE = Enumerable.Range(0, AdvForTest.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(AdvForTest.Substring(x, 2), 16))
                .ToList();
            foreach(var val in tmpE)
            {
                expected += val.ToString()+",";
            }
            //Act
            List<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input);
            string tmpA = "";
            foreach(var val in list[0].Manufacture)
            {
                tmpA +=val.ToString()+",";
            }
            string actual = list[0].Mac + " " + list[0].DBm[0] + " " +tmpA;
            
            //Asset
            Assert.Equal(expected,actual);
        }
    }
}