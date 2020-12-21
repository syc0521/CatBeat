using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
	public InputMaster inputs;
	private JudgeType judgeType;
    private void Start()
    {
		type = Data.Information;
		inputs = new InputMaster();
        if (!NoteController.isAutoPlay)
        {
			//Invoke(nameof(Judge), moveTime - NoteController.goodTime);
		}
	}
	

	void Update()
    {
        if (!NoteController.isAutoPlay)
        {
			if (Time.timeSinceLevelLoad >= Data.Time + moveTime + NoteController.goodTime)
			{
				judgeType = JudgeType.Miss;
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
		if (Data.Index + 1 < NoteController.noteCount)
		{
			NoteController.notes[Data.Index + 1].CanJudge = true;
		}
		Debug.Log(Data + "Miss");
		Data.CanDestroy = true;
		Destroy(gameObject);
	}
    private void AutoPlayMode()
    {
		if (transform.position.x <= endPos.x)
		{
			GenerateHitSound();
			NoteController.combo++;
			NoteController.score += (int)(NoteController.Multiplier * 100);
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
