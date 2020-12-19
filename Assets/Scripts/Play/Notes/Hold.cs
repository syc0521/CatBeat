using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : Note
{
    private GameObject start, end;
    private LineRenderer trail;
    private Vector3 holdEndPos;
    public int type;
    private void Start()
    {
        holdEndPos = new Vector3(Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime), endPos.y);
        start = transform.GetChild(0).gameObject;
        start.transform.position = startPos;
        trail = transform.GetChild(1).gameObject.GetComponent<LineRenderer>();
        end = transform.GetChild(2).gameObject;
        end.transform.position = holdEndPos;
        trail.SetPosition(0, startPos);
        trail.SetPosition(1, holdEndPos);
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Judge()
    {

    }
    public override void Move()
    {
        var time = Time.timeSinceLevelLoad;
        if (time < Data.Time + moveTime)
        {
            start.transform.position = new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, startPos.x, endPos.x),
                start.transform.position.y);
            end.transform.position = new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime + Data.Dur, holdEndPos.x, endPos.x),
                start.transform.position.y);
            trail.SetPosition(0, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime, startPos.x, endPos.x),
                startPos.y));
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime + Data.Dur, holdEndPos.x, endPos.x),
                startPos.y));
        }
        else if (time < Data.Time + moveTime + Data.Dur)
        {
            //start.transform.position = endPos;
            end.transform.position = new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime + Data.Dur, holdEndPos.x, endPos.x),
                start.transform.position.y);
            trail.SetPosition(0, endPos);
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time, Data.Time + moveTime + Data.Dur, holdEndPos.x, endPos.x),
                startPos.y));
        }
        else
        {
            start.GetComponent<SpriteRenderer>().enabled = false;
            end.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
    private void MoveTap(GameObject obj, Vector3 endPos)
    {
        if (obj.transform.position.x > endPos.x)
        {
            var time = Time.timeSinceLevelLoad;
            var endTime = Data.Time + moveTime;
            obj.transform.position = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, endPos.x),
                obj.transform.position.y);
        }
    }
    private void MoveHold()
    {
        var time = Time.timeSinceLevelLoad;
        var endTime = Data.Time + moveTime;
        var newStartPos = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, endPos.x),
                startPos.y);
        var newEndPos = new Vector3(Utils.Lerp(time, Data.Time, endTime, startPos.x, endPos.x),
        startPos.y);
        trail.SetPosition(0, newStartPos);
        trail.SetPosition(1, newEndPos);
    }
}
