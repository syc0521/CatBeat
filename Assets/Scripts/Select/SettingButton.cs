using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GameObject settingCanvas;
    public GameObject leftCanvas, rightCanvas;
    public Toggle autoPlay;
    public Slider speed, vol;
    public Text speedText, volText;
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
        speedText.text = (NoteController.speed / 2.0f).ToString("F1");
    }
    public void OnVolumeChanged()
    {
        NoteController.hitVolume = GetComponent<Slider>().value;
        volText.text = NoteController.hitVolume.ToString("F1");
    }
    public void OnClosePressed()
    {
        settingCanvas.SetActive(false);
        leftCanvas.SetActive(true);
        rightCanvas.SetActive(true);
        Utils.save.SystemSettings = new SaveData.Settings
        {
            isAutoPlay = autoPlay.isOn,
            speed = (int)speed.value,
            hitVol = vol.value,
            ending = Utils.save.SystemSettings.ending,
            secret = Utils.save.SystemSettings.secret,
            endingSeen = Utils.save.SystemSettings.endingSeen,
            tutFinished = Utils.save.SystemSettings.tutFinished
        };
        Utils.SavePrefs();
    }
    public void OnSettingPressed()
    {
        settingCanvas.SetActive(true);
        leftCanvas.SetActive(false);
        rightCanvas.SetActive(false);
        autoPlay.isOn = Utils.save.SystemSettings.isAutoPlay;
        speed.value = Utils.save.SystemSettings.speed;
        vol.value = (float)Utils.save.SystemSettings.hitVol;
    }
    public void OnTutorialPressed()
    {
        NoteController.isTutorial = true;
        NoteController.path = "tut";
        NoteController.diff = Diff.Easy;
        LoadingManager.nextScene = "Play";
        NoteController.isAutoPlay = false;
        NoteController.speed = 2;
        SceneManager.LoadScene("Loading");
    }
}
