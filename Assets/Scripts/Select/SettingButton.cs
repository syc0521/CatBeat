using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GameObject settingCanvas;
    public GameObject selectCanvas;
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
        NoteController.hitVolume = (int)GetComponent<Slider>().value;
    }
    public void OnClosePressed()
    {
        settingCanvas.SetActive(false);
        selectCanvas.SetActive(true);
    }
    public void OnSettingPressed()
    {
        settingCanvas.SetActive(true);
        selectCanvas.SetActive(false);
    }

}
