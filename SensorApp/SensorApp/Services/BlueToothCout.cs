using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeles;
namespace SensorApp.Services
{
    public class BlueToothCout
    {
        public static void CoutBlueToothList(List<BleDeviceModel> ListBlueTooth)
        {
            foreach(var val in ListBlueTooth)
            {
                string output = val.Mac+" "+val.DBm.ToString()+" ";
                foreach(var value in val.Manufacture)
                {
                    output += value.ToString()+",";
                }
                int output_size =output.Length;
                output =output.Substring(0,output_size-1);
                Console.WriteLine(output);
            }
        }
    }
}
