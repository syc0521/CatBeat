using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : Note
{
    public GameObject fx;
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Time.timeSinceLevelLoad >= Data.Time + Data.Dur * 0.8f)
        {
            NoteController.combo++;
            Instantiate(fx);
            Destroy(gameObject);
        }
    }
}
