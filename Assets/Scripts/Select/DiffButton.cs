using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffButton : MonoBehaviour
{
    public void OnPressed()
    {
        var controller = GameObject.FindWithTag("GameController").GetComponent<SongManager>();
        switch (gameObject.name)
        {
            case "ez":
                controller.JumpScene(Diff.Easy);
                break;
            case "nm":
                controller.JumpScene(Diff.Normal);
                break;
            case "hd":
                controller.JumpScene(Diff.Hard);
                break;
        }
    }
}
