using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandButton : MonoBehaviour
{
    private int count = 0;
    private void OnMouseDown()
    {
        Debug.Log(MainSceneManager.ending);
        if (MainSceneManager.ending && !MainSceneManager.secret && count < 5)
        {
            count++;
        }
        if (count == 5)
        {
            Debug.Log("secret unlocked");
            MainSceneManager.secret = true;
            Utils.save.SystemSettings = new SaveData.Settings
            {
                isAutoPlay = Utils.save.SystemSettings.isAutoPlay,
                speed = Utils.save.SystemSettings.speed,
                hitVol = Utils.save.SystemSettings.hitVol,
                ending = MainSceneManager.ending,
                secret = MainSceneManager.secret
            };
            Utils.SavePrefs();
        }
    }
}
