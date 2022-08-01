using Common.Modeles;

namespace SensorApp.Servis
{
    public interface IBlePhrase
    {
        IEnumerable<BleDeviceModel> PhraseBlue(string com,int scanstodo);
        IEnumerable<byte> StringToByteList(string hex);
    }
}