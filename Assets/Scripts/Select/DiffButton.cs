using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffButton : MonoBehaviour
{
    public Image ez, nm, hd;
    public void OnPressed()
    {
        ez.color = Color.white;
        nm.color = Color.white;
        hd.color = Color.white;
        GetComponent<Image>().color = new Color(0.75f, 0.65f, 1.0f);
        switch (gameObject.name)
        {
            case "ez":
                NoteController.diff = Diff.Easy;
                break;
            case "nm":
                NoteController.diff = Diff.Normal;
                break;
            case "hd":
                NoteController.diff = Diff.Hard;
                break;
        }
    }
    public void OnPlayPressed()
    {
        var controller = GameObject.FindWithTag("GameController").GetComponent<SongManager>();
        controller.JumpScene(NoteController.diff);
    }
}
