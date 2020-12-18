using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : Note
{
    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        speed = 0.15f;
    }

    void Update()
    {
        if (transform.position == endPos)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
}
