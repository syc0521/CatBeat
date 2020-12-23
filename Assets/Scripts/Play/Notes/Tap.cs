using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
    private void Start()
    {
		type = Data.Information;
	}
	

	void Update()
    {
        if (!NoteController.isAutoPlay)
        {
			if (Time.timeSinceLevelLoad >= Data.Time + moveTime + NoteController.goodTime)
			{
				DestroyMissNote();
			}
		}
        else
        {
			AutoPlayMode();
        }
	}
	private void DestroyMissNote()
	{
		NoteController.combo = 0;
		if (Data.Index < NoteController.noteCount - 1)
		{
			NoteController.notes[Data.Index + 1].CanJudge = true;
		}
		Debug.Log(Data + "Miss");
		NoteController.miss++;
		NoteController.combo = 0;
		Data.CanDestroy = true;
		Destroy(gameObject);
	}
    private void AutoPlayMode()
    {
		if (transform.position.x <= endPos.x)
		{
			GenerateHitSound();
			NoteController.combo++;
			NoteController.score += (int)(NoteController.Multiplier * 100.0f);
			Destroy(gameObject);
		}
	}

	private void GenerateHitSound()
    {
        if (type == 1)
        {
            Instantiate(R_FX);
        }
        else if (type == 2)
        {
            Instantiate(B_FX);
        }
        else
        {
            Instantiate(R_FX);
            Instantiate(B_FX);
        }
    }


}
