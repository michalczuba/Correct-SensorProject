using Common.Modeles;

namespace SensorApp.Servis
{
    public interface IBlePhrase
    {
        List<BleDeviceModel> PhraseBlue(string com);
        List<byte> StringToByteList(string hex);
    }
}