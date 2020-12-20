using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
    private void Start()
    {
        type = Data.Information;
    }
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }
    void Update()
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

    public JudgeType JudgeNote(NoteData note)
	{
		float sceneTime = Time.timeSinceLevelLoad;
		float time = note.Time;
		float exactTime = time + moveTime;
		var perfectTime = NoteController.perfectTime;
		var greatTime = NoteController.greatTime;
		var goodTime = NoteController.goodTime;
		if (sceneTime <= exactTime + perfectTime && sceneTime > exactTime - perfectTime)
		{
			Debug.Log(note + "perfect");
			NoteController.perfect++;
			return JudgeType.Perfect;
		}
		else if (sceneTime < exactTime + greatTime && sceneTime > exactTime + perfectTime)
		{
			Debug.Log(note + "Lgreat");
			NoteController.great++;
			return JudgeType.LateGreat;
		}
		else if (sceneTime > exactTime - greatTime && sceneTime < exactTime - perfectTime)
		{
			Debug.Log(note + "Egreat");
			NoteController.great++;
			return JudgeType.EarlyGreat;
		}
		else if (sceneTime < exactTime + goodTime && sceneTime > exactTime + greatTime)
		{
			Debug.Log(note + "Lgood");
			NoteController.good++;
			return JudgeType.LateGood;
		}
		else if (sceneTime > exactTime - goodTime && sceneTime < exactTime - greatTime)
		{
			Debug.Log(note + "Egood");
			NoteController.good++;
			return JudgeType.EarlyGood;
		}
		else if (sceneTime < exactTime - goodTime)
		{
			return JudgeType.Miss;
		}
		return JudgeType.Default;
	}

}
