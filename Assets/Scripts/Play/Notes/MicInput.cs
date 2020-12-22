using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : Note
{
    public GameObject fx;
    public float[] volume;
    public float realVolume;//获取的麦克风音量
    private AudioClip[] micRecord;
    public string[] Devices;
    private float holdTime;
    private bool canInput = false;
    private bool isPerfect = false;
    private void Awake()
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
        else
        {
            Debug.LogError("Can't find Microphone");
        }
    }
    private void Start()
    {
        
    }
    private void Update()
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
        if (realVolume >= 0.7f && canInput)
        {
            holdTime += Time.deltaTime;
            NoteController.score += (int)(NoteController.Multiplier * 5.0f);
        }
        if (holdTime > Data.Dur * 0.5f && !isPerfect)
        {
            isPerfect = true;
        }
        if (holdTime > Data.Dur * 0.8f)
        {
            canInput = false;
            if (isPerfect)
            {
                NoteController.perfect++;
                NoteController.combo++;
                Instantiate(fx);
            }
            else
            {
                NoteController.miss++;
                NoteController.combo = 0;
            }
            Destroy(gameObject);
        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime)
        {
            NoteController.score += (int)(NoteController.Multiplier * 5.0f);
        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            NoteController.combo++;
            Instantiate(fx);
            Destroy(gameObject);
        }
    }
    float GetMaxVolume(int x)
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
