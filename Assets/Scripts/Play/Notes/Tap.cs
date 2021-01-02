using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
	public Animator destroyAnim;
	public bool firstDestroy = true;
    private void Start()
    {
		destroyAnim = transform.GetComponent<Animator>();
		type = Data.Information;
	}
	

	public override void Update()
    {
		base.Update();
        if (!NoteController.isAutoPlay)
        {
			if (Time.timeSinceLevelLoad >= Data.Time + moveTime + NoteController.goodTime && firstDestroy)
			{
				firstDestroy = false;
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
		ShowJudge(JudgeType.Miss);
		Destroy(gameObject);
	}
    private void AutoPlayMode()
    {
		if (transform.position.x <= endPos.x)
		{
			GenerateHitSound();
			//ShowJudge(JudgeType.Perfect);
			//NoteController.combo++;
			//NoteController.score += (int)(NoteController.Multiplier * 100.0f);
			StartCoroutine(DestroyAnim(JudgeType.Perfect));
			//Destroy(gameObject);
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
	public IEnumerator DestroyAnim(JudgeType type)
    {
		if(firstDestroy)
        {
			firstDestroy = false;
			ShowJudge(type);
			InputController.TapJudgeFinished(type);
			//NoteController.combo++;
			//NoteController.score += (int)(NoteController.Multiplier * 100.0f);
			destroyAnim.Play("tap");
			yield return new WaitForSeconds(0.3f);
			Destroy(gameObject);
			yield break;
        }
		
    }

}
