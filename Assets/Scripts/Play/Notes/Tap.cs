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
		Judge();
	}
	private void Tap_Red_performed(InputAction.CallbackContext obj)
	{
		if (Data.CanJudge)
		{
			judgeType = JudgeNote();
			Debug.Log(judgeType);
            if (judgeType != JudgeType.Default)
            {
				if (Data.Index + 1 < NoteController.noteCount)
				{
					NoteController.notes[Data.Index + 1].CanJudge = true;
				}
				Instantiate(R_FX);
				inputs.PlayController.Tap_Red.Disable();
				Destroy(gameObject);
			}
		}	
	}

	private void Tap_Blue_performed(InputAction.CallbackContext obj)
    {
		if (Data.CanJudge)
		{
			judgeType = JudgeNote();
			if (judgeType != JudgeType.Default)
			{
				if (Data.Index + 1 < NoteController.noteCount)
				{
					NoteController.notes[Data.Index + 1].CanJudge = true;
				}
				Instantiate(B_FX);
				inputs.PlayController.Tap_Red.Disable();
				Destroy(gameObject);
			}
		}
	}
	private void Tap_Purple_performed(InputAction.CallbackContext obj)
	{
		if (Data.CanJudge)
		{
			judgeType = JudgeNote();
			if (judgeType != JudgeType.Default)
			{
				if (Data.Index + 1 < NoteController.noteCount)
				{
					NoteController.notes[Data.Index + 1].CanJudge = true;
				}
				Instantiate(B_FX);
				inputs.PlayController.Tap_Purple.Disable();
				Destroy(gameObject);
			}
		}
	}

	public override void Judge()
    {
		switch (Data.Information)
		{
			case 1:
				inputs.PlayController.Tap_Red.Enable();
				inputs.PlayController.Tap_Red.started += Tap_Red_performed;
				break;
			case 2:
				inputs.PlayController.Tap_Blue.Enable();
				inputs.PlayController.Tap_Blue.started += Tap_Blue_performed;
				break;
			case 3:
				inputs.PlayController.Tap_Purple.Enable();
				inputs.PlayController.Tap_Purple.started += Tap_Purple_performed;
				break;
		}
	}


	void Update()
    {
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + NoteController.goodTime && judgeType == JudgeType.Miss)
        {
			StartCoroutine(DestroyMissNote());
        }
	}
	private IEnumerator DestroyMissNote()
	{
		yield return new WaitForSeconds(0.02f);
		NoteController.combo = 0;
		if (Data.Index + 1 < NoteController.noteCount)
		{
			NoteController.notes[Data.Index + 1].CanJudge = true;
		}
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
	private void UserPlayMode()
    {
		Judge();

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
