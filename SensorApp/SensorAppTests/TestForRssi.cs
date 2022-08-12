using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
using SensorApp.Services;
using SensorApp.Servis;

namespace SensorAppTests
{
    public class TestForRssi
    {
        [Theory]
        [InlineData(@"
        Device (new): [37m60:77:71:61:02:48[0m (public), -74 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
        Device (new): [37m54:6c:0e:ad:7d:22[0m (public), -65 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
	    0x12: <50009001>
        Device (new): [37m60:77:71:60:cf:08[0m (public), -67 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
		Device (update): [37m60:77:71:61:02:48[0m (public), -76 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -67 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -71 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (new): [37m60:77:71:60:cf:08[0m (public), -73 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>", "-70,11")]
        public void AvregeRssiSchouldWork(string input,string expected)
        {
            //Arange
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input);
            double avrege  = CheckingRssi.CheckingAvregeRssi(list);
			string actual = avrege.ToString("0.##");
            //Asset
            Assert.Equal(expected, actual);
        }
		[Theory]
		[InlineData(@"
        Device (new): [37m60:77:71:61:02:48[0m (public), -74 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
        Device (new): [37m54:6c:0e:ad:7d:22[0m (public), -65 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
	    0x12: <50009001>
        Device (new): [37m60:77:71:60:cf:08[0m (public), -67 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
		Device (update): [37m60:77:71:61:02:48[0m (public), -76 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -67 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -71 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (new): [37m60:77:71:60:cf:08[0m (public), -73 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>", "-69")]
		public void MedianRssiSchouldWork(string input, string expected)
        {
            //Arange
            IBlePhrase blePhrase = new BlePhrase();
            //Act
            IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
            list = blePhrase.PhraseBlue(input);
            double avrege = CheckingRssi.ChceckMedianRssi(list);
            string actual = avrege.ToString("0.##");
            //Asset
            Assert.Equal(expected, actual);
        }
		[Theory]
		[InlineData(@"
        Device (new): [37m60:77:71:61:02:48[0m (public), -74 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
        Device (new): [37m54:6c:0e:ad:7d:22[0m (public), -65 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
	    0x12: <50009001>
        Device (new): [37m60:77:71:60:cf:08[0m (public), -67 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
		Device (update): [37m60:77:71:61:02:48[0m (public), -76 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -67 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -71 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -73 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>", "28,57 42,86 57,14 ")]
		public void PackagesPercentSchouldWork(string input, string expected)
        {
			//Arange
			IBlePhrase blePhrase = new BlePhrase();
			//Act
			IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
			list = blePhrase.PhraseBlue(input);
			double pacakges = 7;

			string actual="";
			foreach(var val in list)
            {
				double tmp = (val.DBm.Count*100)/pacakges;
				actual += tmp.ToString("0.##")+" ";
            }
			//Asset
			Assert.Equal(expected, actual);
		}
		[Theory]
		[InlineData(@"
        Device (new): [37m60:77:71:61:02:48[0m (public), -74 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
        Device (new): [37m54:6c:0e:ad:7d:22[0m (public), -65 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
	    0x12: <50009001>
        Device (new): [37m60:77:71:60:cf:08[0m (public), -67 dBm 
	    Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
	    0x12: <1e005000>
		Device (update): [37m60:77:71:61:02:48[0m (public), -76 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -67 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m54:6c:0e:ad:7d:22[0m (public), -69 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2206[0m'
		0x12: <50009001>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -71 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>
		Device (update): [37m60:77:71:60:cf:08[0m (public), -73 dBm 
		Flags: <06> Manufacturer: <020df0e072a000aa000000b2000000> Complete Local Name: '[36mHIVE v2202[0m'
		0x12: <1e005000>", "42,86")]
		public void AvregePackagesPercentSchouldWork(string input, string expected)
		{
			//Arange
			IBlePhrase blePhrase = new BlePhrase();
			//Act
			IEnumerable<BleDeviceModel> list = new List<BleDeviceModel>();
			list = blePhrase.PhraseBlue(input);
			double pacakges = 7;

			string actual = "";
			double tmp = 0;
			foreach (var val in list)
			{
				 tmp += (val.DBm.Count * 100) / pacakges;
			}
			tmp /= list.Count();
			actual += tmp.ToString("0.##");
			//Asset
			Assert.Equal(expected, actual);
		}
	}
}
