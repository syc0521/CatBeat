using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTap : Note
{
    [HideInInspector]
    public int tapCount = 0;
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private IEnumerator ReduceCount()
    {
        while (tapCount > 0)
        {
            tapCount--;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
