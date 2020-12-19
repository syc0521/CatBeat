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

    /// <summary>
    /// 生成打击音效
    /// </summary>
    void Update()
    {
        noteDestroy();
    }
    private void FixedUpdate()
    {
        Move();
    }

    public override void noteDestroy()
    {
        if(Data.CanDestroy)
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
            Destroy(this.gameObject);
        }
            
    }


}
