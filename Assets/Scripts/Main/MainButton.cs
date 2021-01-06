using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void OnPlayPressed()
    {
        if (!Utils.save.SystemSettings.tutFinished)
        {
            NoteController.isTutorial = true;
            NoteController.path = "tut";
            NoteController.diff = Diff.Easy;
            LoadingManager.nextScene = "Play";
            NoteController.isAutoPlay = false;
            NoteController.speed = 2;
            Utils.save.SystemSettings = new SaveData.Settings
            {
                isAutoPlay = Utils.save.SystemSettings.isAutoPlay,
                speed = Utils.save.SystemSettings.speed,
                hitVol = Utils.save.SystemSettings.hitVol,
                ending = Utils.save.SystemSettings.ending,
                secret = Utils.save.SystemSettings.secret,
                endingSeen = Utils.save.SystemSettings.endingSeen,
                tutFinished = true
            };
            Utils.SavePrefs();
            SceneManager.LoadScene("Loading");
        }
        else
        {
            LoadingManager.nextScene = "Select";
            SceneManager.LoadScene("Loading");
        }
    }
}
