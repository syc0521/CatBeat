using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : Note
{
    private GameObject start, end;
    private LineRenderer trail;
    private Vector3 holdEndPos;
    public int type;
    public GameObject R_FX, B_FX;
    private bool key = false;
    public bool isHold = false;
    private float holdTime = 0f;
    public JudgeType firstType, secondType, finalType;

    private void Start()
    {
        type = Data.Information;
        GenerateHold();
    }
    public override void Update()
    {
        base.Update();
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime - NoteController.goodTime &&
            Time.timeSinceLevelLoad <= Data.Time + moveTime + Data.Dur && isHold)
        {
            if (type == 1)
            {
                JudgeRedHoldEnd();
            }
            else if (type == 2)
            {
                JudgeBlueHoldEnd();
            }
            if (holdTime > Data.Dur - NoteController.greatTime)
            {
                if (Data.Index < NoteController.noteCount - 1)
                {
                    NoteController.notes[Data.Index + 1].CanJudge = true;
                }
                secondType = JudgeType.Perfect;
                finalType = GetHoldJudge(firstType, secondType);
                Debug.Log(firstType);
                Debug.Log(secondType);
                Debug.Log(Data + finalType.ToString());
                isHold = false;
                Destroy(gameObject);
            }
        }
    }

    private void JudgeBlueHoldEnd()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.K))
        {
            holdTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("up");
            Instantiate(B_FX);
            HoldUpJudge();
        }
    }

    private void JudgeRedHoldEnd()
    {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.J))
        {
            holdTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("up");
            Instantiate(R_FX);
            HoldUpJudge();
        }
    }

    private void HoldUpJudge()
    {
        secondType = GetSecondType();
        finalType = GetHoldJudge(firstType, secondType);
        Debug.Log(Data + finalType.ToString());
        if (Data.Index < NoteController.noteCount - 1)
        {
            NoteController.notes[Data.Index + 1].CanJudge = true;
        }
        isHold = false;
        Destroy(gameObject);
    }

    private JudgeType GetSecondType()
    {
        if (holdTime < Data.Dur - NoteController.goodTime * 1.2f)
        {
            return JudgeType.Miss;
        }
        else if (holdTime < Data.Dur - NoteController.goodTime * 0.8f)
        {
            return JudgeType.EarlyGreat;
        }
        else
        {
            return JudgeType.Perfect;
        }
    }
    private void GenerateHold()
    {
        holdEndPos = new Vector3(Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime) + startPos.x, endPos.y);
        start = transform.GetChild(0).gameObject;
        start.transform.position = startPos;
        trail = transform.GetChild(1).gameObject.GetComponent<LineRenderer>();
        end = transform.GetChild(2).gameObject;
        end.transform.position = holdEndPos;
        trail.SetPosition(0, startPos);
        trail.SetPosition(1, holdEndPos);
    }

    public override void Move()
    {
        var time = Time.timeSinceLevelLoad;
        var durPos = Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime);
        if (time < Data.Time + moveTime)
        {
            start.transform.position = new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, startPos.x, endPos.x),
                start.transform.position.y);
            trail.SetPosition(0, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, startPos.x, endPos.x),
                startPos.y));
            end.transform.position = new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, holdEndPos.x, endPos.x + durPos),
                start.transform.position.y);
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, holdEndPos.x, endPos.x + durPos),
                startPos.y));
        }
        else if (time < Data.Time + moveTime + Data.Dur)
        {
            start.transform.position = endPos;
            end.transform.position = new Vector3(Utils.Lerp(time, Data.Time + moveTime, Data.Time + moveTime + Data.Dur, endPos.x + durPos, endPos.x),
                start.transform.position.y);
            trail.SetPosition(0, endPos);
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time + moveTime, Data.Time + moveTime + Data.Dur, endPos.x + durPos, endPos.x),
                startPos.y));
            if (!key)
            {
                key = true;
                if (NoteController.isAutoPlay)
                {
                    GenerateHitSound();
                }
            }
        }
        else
        {
            if (NoteController.isAutoPlay)
            {
                AutoPlayMode();
                Destroy(gameObject);
            }
        }
        if (time > Data.Time + moveTime + NoteController.goodTime)
        {
            if (!NoteController.isAutoPlay)
            {
                if (!isHold)
                {
                    finalType = JudgeType.Miss;
                    if (Data.Index < NoteController.noteCount - 1)
                    {
                        NoteController.notes[Data.Index + 1].CanJudge = true;
                    }
                    NoteController.miss++;
                    NoteController.combo = 0;
                    Debug.Log("miss");
                    Destroy(gameObject);
                }
            }
        }
    }
    private void AutoPlayMode()
    {
        GenerateHitSound();
        NoteController.combo++;
        NoteController.score += (int)(NoteController.Multiplier * 200.0f);
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
    private JudgeType GetHoldJudge(JudgeType first, JudgeType second)
    {
        if (first.Equals(JudgeType.Perfect) && second.Equals(JudgeType.Perfect))
        {
            NoteController.perfect++;
            NoteController.combo++;
            NoteController.score += (int)(NoteController.Multiplier * 200.0f);
            return JudgeType.Perfect;
        }
        else if (IsGood(first) && IsGood(second) || second.Equals(JudgeType.Miss))
        {
            NoteController.good++;
            NoteController.combo++;
            NoteController.score += (int)(NoteController.Multiplier * 100.0f);
            return JudgeType.EarlyGood;
        }
        else
        {
            NoteController.great++;
            NoteController.combo++;
            NoteController.score += (int)(NoteController.Multiplier * 160.0f);
            return JudgeType.LateGreat;
        }

        bool IsGood(JudgeType type) => type.Equals(JudgeType.EarlyGood) || type.Equals(JudgeType.LateGood);
    }
}
