using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : Note
{
    public GameObject fx;


    private void Start()
    {
        
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime)
        {
            NoteController.score += (int)(NoteController.Multiplier * 5);
        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            NoteController.combo++;
            Instantiate(fx);
            Destroy(gameObject);
        }
    }
}
