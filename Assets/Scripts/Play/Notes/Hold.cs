using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : Note
{
   public override void Judge()
   {

   }
    public override void Move()
    {
        if (this.gameObject.transform.position.y>endPos.y)
        {
            transform.position = new Vector3(transform.position.x,
                Utils.Lerp(Time.timeSinceLevelLoad, data.Time, noteDropTime + data.Time,startPos.y , endPos.y));
        }
        else
        {
            Destroy(this);
        }
    }
}
