using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void OnPressed()
    {
        if (Utils.save.SystemSettings.ending && !Utils.save.SystemSettings.endingSeen)
        {
            LoadingManager.nextScene = "StaffRolling";
            SceneManager.LoadScene("Loading");
            Utils.save.SystemSettings = new SaveData.Settings
            {
                isAutoPlay = Utils.save.SystemSettings.isAutoPlay,
                speed = Utils.save.SystemSettings.speed,
                hitVol = Utils.save.SystemSettings.hitVol,
                ending = Utils.save.SystemSettings.ending,
                secret = Utils.save.SystemSettings.secret,
                endingSeen = true
            };
            Utils.SavePrefs();
        }
        else
        {
            LoadingManager.nextScene = "Select";
            SceneManager.LoadScene("Loading");
        }
    }
    public void OnRetryPressed()
    {
        LoadingManager.nextScene = "Play";
        SceneManager.LoadScene("Loading");
    }
}
