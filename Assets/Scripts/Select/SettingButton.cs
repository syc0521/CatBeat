using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    private void Start()
    {
        NoteController.isAutoPlay = false;
    }
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
        Debug.Log(NoteController.isAutoPlay);
    }
}
