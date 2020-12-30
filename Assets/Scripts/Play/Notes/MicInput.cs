using UnityEngine;

public class MicInput : Note
{
    public GameObject fx;
    private float holdTime;
    private bool canInput = false;
    private bool isPerfect = false;
    private void Start()
    {
        moveTime = NoteController.NoteSpeed;
    }
    public override void Update()
    {
        base.Update();
        if (NoteController.isAutoPlay)
        {
            AutoPlayMode();
        }
        else
        {
            UserPlayMode();
        }
    }
    private void UserPlayMode()
    {

        if (Time.timeSinceLevelLoad >= Data.Time + moveTime - NoteController.goodTime * 1.5f)
        {
            canInput = true;
            if (MicrophoneController.realVolume >= 0.55f && canInput)
            {
                holdTime += Time.deltaTime;
                NoteController.score += (int)(NoteController.Multiplier * 15.0f);
            }
            if (holdTime > Data.Dur * 0.5f && !isPerfect)
            {
                isPerfect = true;
            }
            if (holdTime > Data.Dur * 0.8f)
            {
                canInput = false;
                if (isPerfect)
                {
                    NoteController.perfect++;
                    NoteController.combo++;
                    Instantiate(fx);
                }
                else
                {
                    NoteController.miss++;
                    NoteController.combo = 0;
                }
                if (Data.Index < NoteController.noteCount - 1)
                {
                    NoteController.notes[Data.Index + 1].CanJudge = true;
                }
                Destroy(gameObject);
            }

        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            if (isPerfect)
            {
                NoteController.perfect++;
                NoteController.combo++;
                ShowJudge(JudgeType.Perfect);
                Instantiate(fx);
            }
            else
            {
                NoteController.miss++;
                NoteController.combo = 0;
                ShowJudge(JudgeType.Miss);
            }
            if (Data.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[Data.Index + 1].CanJudge = true;
            }
            Destroy(gameObject);
        }
    }

    
    private void AutoPlayMode()
    {
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime)
        {
            NoteController.score += (int)(NoteController.Multiplier * 15.0f);
        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            NoteController.combo++;
            Instantiate(fx);
            ShowJudge(JudgeType.Perfect);
            Destroy(gameObject);
        }
    }
}
