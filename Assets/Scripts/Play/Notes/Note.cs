using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public NoteData Data { set; get; }

    public Vector3 startPos, endPos;
    [HideInInspector]
    public float moveTime;
    public bool isStickJudged;
    private void Awake()
    {
        moveTime = NoteController.noteSpeed;
    }
    public virtual void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        if (gameObject.transform.position.x > endPos.x)
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
    public abstract void Judge();
	public virtual JudgeType JudgeNote()
	{
		float sceneTime = Time.timeSinceLevelLoad;
		float exactTime = Data.Time + NoteController.noteSpeed + 0.045f;
		var perfectTime = NoteController.perfectTime;
		var greatTime = NoteController.greatTime;
		var goodTime = NoteController.goodTime;
        if (Data.CanJudge)
        {
			if (sceneTime <= exactTime + perfectTime && sceneTime > exactTime - perfectTime)
			{
				Debug.Log(Data + "perfect");
				NoteController.perfect++;
				return JudgeType.Perfect;
			}
			else if (sceneTime < exactTime + greatTime && sceneTime > exactTime + perfectTime)
			{
				Debug.Log(Data + "Lgreat");
				NoteController.great++;
				return JudgeType.LateGreat;
			}
			else if (sceneTime > exactTime - greatTime && sceneTime < exactTime - perfectTime)
			{
				Debug.Log(Data + "Egreat");
				NoteController.great++;
				return JudgeType.EarlyGreat;
			}
			else if (sceneTime < exactTime + goodTime - 0.05f && sceneTime > exactTime + greatTime)
			{
				Debug.Log(Data + "Lgood");
				NoteController.good++;
				return JudgeType.LateGood;
			}
			else if (sceneTime > exactTime - goodTime && sceneTime < exactTime - greatTime)
			{
				Debug.Log(Data + "Egood");
				NoteController.good++;
				return JudgeType.EarlyGood;
			}
			else if (sceneTime < exactTime - goodTime)
			{
				return JudgeType.Default;
			}
			else if (sceneTime > exactTime + goodTime - 0.05f)
			{
				return JudgeType.Miss;
			}
		}
		return JudgeType.Default;
	}

}
