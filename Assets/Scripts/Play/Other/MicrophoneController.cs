using UnityEngine;

public class MicrophoneController : MonoBehaviour
{
    public float[] volume;
    public static float realVolume;//获取的麦克风音量
    private AudioClip[] micRecord;
    public string[] Devices;
    private void Start()
    {
        Devices = Microphone.devices;
        if (Devices.Length > 0)
        {
            micRecord = new AudioClip[Devices.Length];
            volume = new float[Devices.Length];
            for (int i = 0; i < Devices.Length; i++)
            {
                if (Microphone.devices[i].IsNormalized())
                {
                    micRecord[i] = Microphone.Start(Devices[i], true, 999, 44100);
                }
            }
        }

    }
    private void Update()
    {
        GetVolume();
    }
    private void GetVolume()
    {
        if (Devices.Length > 0)
        {
            for (int i = 0; i < Devices.Length; i++)
            {
                volume[i] = GetMaxVolume(i);
                if (volume[i] != 0)
                {
                    realVolume = volume[i];
                }
            }
        }
    }
    private float GetMaxVolume(int x)
    {
        float maxVolume = 0f;
        //剪切音频
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(Devices[x]) - 128 + 1;
        if (offset < 0)
        {
            return 0;
        }
        micRecord[x].GetData(volumeData, offset);

        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];//修改音量的敏感值
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;
    }


}
