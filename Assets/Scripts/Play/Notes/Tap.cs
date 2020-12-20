using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
	public InputMaster inputs;
    private void Start()
    {
		type = Data.Information;
		inputs = new InputMaster();
        switch (Data.Information)
        {
			case 1:
				inputs.PlayController.Tap_Red.Enable();
				inputs.PlayController.Tap_Red.performed += Tap_Red_performed;
				break;
			case 2:
				inputs.PlayController.Tap_Blue.Enable();
				inputs.PlayController.Tap_Blue.performed += Tap_Blue_performed;
				break;
			case 3:
				inputs.PlayController.Tap_Red.Enable();
				inputs.PlayController.Tap_Red.performed += Tap_Red_performed;
				break;
        }

	}

    private void Tap_Blue_performed(InputAction.CallbackContext obj)
    {
		Judge();
		Debug.Log("performed");
		NoteController.notes[NoteController.notes.FindIndex(item => item.Equals(Data)) + 1].CanJudge = true;
		Instantiate(B_FX);
		Destroy(gameObject);
	}

    public override void Judge()
    {
		JudgeNote();

	}

    private void Tap_Red_performed(InputAction.CallbackContext obj)
    {
		Judge();
		Debug.Log("performed");
		NoteController.notes[NoteController.notes.FindIndex(item => item.Equals(Data)) + 1].CanJudge = true;
		Instantiate(R_FX);
		Destroy(gameObject);
	}

	void Update()
    {

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
