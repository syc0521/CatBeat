using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : Note
{
    private LineRenderer trail;
    private Vector3 holdEndPos;
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        trail = transform.GetChild(0).gameObject.GetComponent<LineRenderer>();
        holdEndPos = new Vector3(Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime) + startPos.x, endPos.y);
        trail.SetPosition(0, startPos);
        trail.SetPosition(1, holdEndPos);
    }
    public override void Move()
    {
        var time = Time.timeSinceLevelLoad;
        var durPos = Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime);
        if (time < Data.Time + moveTime)
        {
            trail.SetPosition(0, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, startPos.x, endPos.x),
                startPos.y));
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, holdEndPos.x, endPos.x + durPos),
                startPos.y));
        }
        else if (time < Data.Time + moveTime + Data.Dur)
        {
            trail.SetPosition(0, endPos);
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time + moveTime, Data.Time + moveTime + Data.Dur, endPos.x + durPos, endPos.x),
                startPos.y));
        }
        else
        {
            NoteController.combo++;
            Destroy(gameObject);
        }
    }

}
