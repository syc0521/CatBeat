using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : Note
{
    public GameObject R_FX, B_FX;
    public int type;
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        //speed = 0.15f;
    }
    /// <summary>
    /// 生成打击音效
    /// </summary>
    void Update()
    {
        if (transform.position == endPos)
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
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        if (this.gameObject.transform.position.y > endPos.y)
        {
            transform.position = new Vector3(transform.position.x,
                Utils.Lerp(Time.timeSinceLevelLoad, data.Time, noteDropTime + data.Time,startPos.y,endPos.y));
        }
        else
        {
            Destroy(this);
        }
    }
}
