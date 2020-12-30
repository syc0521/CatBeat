using System;
using System.Collections;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public NoteData Data { set; get; }
    public Vector3 startPos, endPos, judgePos;
    public GameObject[] judge;
    [HideInInspector]
    public float moveTime;
    private void Awake()
    {
        moveTime = NoteController.noteSpeed;
    }
    public virtual void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        if (Time.timeSinceLevelLoad < Data.Time + moveTime)
        {
            var time = Time.timeSinceLevelLoad;
            var endTime = Data.Time + moveTime;
			var fixedEndPos = endPos.x + 0.1f;
			transform.position = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, fixedEndPos),
                transform.position.y);
        }
        else
        {
			transform.position = endPos;
        }
    }
    public virtual void ShowJudge(JudgeType type)
    {
        switch (type)
        {
            case JudgeType.Perfect:
                Instantiate(judge[0]);
                break;
            case JudgeType.EarlyGreat:
                Instantiate(judge[1]);
                break;
            case JudgeType.LateGreat:
                Instantiate(judge[1]);
                break;
            case JudgeType.EarlyGood:
                Instantiate(judge[2]);
                break;
            case JudgeType.LateGood:
                Instantiate(judge[2]);
                break;
            case JudgeType.Miss:
                Instantiate(judge[3]);
                break;
        }
    }
}
