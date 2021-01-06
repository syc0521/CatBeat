using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffButton : MonoBehaviour
{
    public Image ez, nm, hd;
    public void OnPressed()
    {
        //统一设置成白色
        ez.color = Color.white;
        nm.color = Color.white;
        hd.color = Color.white;
        GetComponent<Image>().color = new Color(0.75f, 0.65f, 1.0f);//修改当前Button颜色
        switch (gameObject.name)//切换难度
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
        NoteController.isTutorial = false;
        var controller = GameObject.FindWithTag("GameController").GetComponent<SongManager>();
        controller.JumpScene(NoteController.diff);//跳转Play场景
    }
}
