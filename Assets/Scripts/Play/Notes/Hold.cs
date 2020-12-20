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
    private void Start()
    {
        type = Data.Information;
        holdEndPos = new Vector3(Data.Dur * (Mathf.Abs(startPos.x - endPos.x) / moveTime) + startPos.x, endPos.y);
        start = transform.GetChild(0).gameObject;
        start.transform.position = startPos;
        trail = transform.GetChild(1).gameObject.GetComponent<LineRenderer>();
        end = transform.GetChild(2).gameObject;
        end.transform.position = holdEndPos;
        trail.SetPosition(0, startPos);
        trail.SetPosition(1, holdEndPos);
    }
    public override void Judge()
    {

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
            end.transform.position = new Vector3(Utils.Lerp(time, Data.Time + moveTime, Data.Time + moveTime + Data.Dur, endPos.x + durPos, endPos.x),
                start.transform.position.y);
            trail.SetPosition(0, endPos);
            trail.SetPosition(1, new Vector3(Utils.Lerp(time, Data.Time + moveTime, Data.Time + moveTime + Data.Dur, endPos.x + durPos, endPos.x),
                startPos.y));
            if (!key)
            {
                key = true;
                GenerateHitSound();
            }
        }
        else
        {
            start.GetComponent<SpriteRenderer>().enabled = false;
            end.GetComponent<SpriteRenderer>().enabled = false;
            GenerateHitSound();
            NoteController.combo++;
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
}
