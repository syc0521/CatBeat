using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public Vector3 endPos;
    public float speed = 0.1f;
    public virtual void Move()
    {
        if (transform.position.x >= endPos.x)
        {
            transform.position += Vector3.left * speed;
        }
        else
        {
            transform.position = endPos;
        }
    }
    public abstract void Judge();
}
