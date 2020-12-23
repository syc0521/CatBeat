using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongButton : MonoBehaviour
{
    public Song song;
    void Start()
    {
        Text songText = transform.GetChild(0).GetComponent<Text>();
        songText.text = song.Name;
    }
    public void OnPressed()
    {
        var controller = GameObject.FindWithTag("GameController").GetComponent<ReadList>();
        controller.currentSong = song;
    }

}
