using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GameObject settingCanvas;
    public GameObject selectCanvas;
    public Toggle autoPlay;
    public Slider speed, vol;
    public void OnAutoPressed()
    {
        if (GetComponent<Toggle>().isOn)
        {
            NoteController.isAutoPlay = true;
        }
        else
        {
            NoteController.isAutoPlay = false;
        }
    }
    public void OnSpeedChanged()
    {
        NoteController.speed = (int)GetComponent<Slider>().value;
    }
    public void OnVolumeChanged()
    {
        NoteController.hitVolume = GetComponent<Slider>().value;
    }
    public void OnClosePressed()
    {
        settingCanvas.SetActive(false);
        selectCanvas.SetActive(true);
        SaveData save = Utils.save;
        save.SystemSettings = new SaveData.Settings
        {
            isAutoPlay = autoPlay.isOn,
            speed = (int)speed.value,
            hitVol = vol.value
        };
        Utils.SavePrefs();
    }
    public void OnSettingPressed()
    {
        settingCanvas.SetActive(true);
        selectCanvas.SetActive(false);
        autoPlay.isOn = Utils.save.SystemSettings.isAutoPlay;
        speed.value = Utils.save.SystemSettings.speed;
        vol.value = (float)Utils.save.SystemSettings.hitVol;
    }

}
