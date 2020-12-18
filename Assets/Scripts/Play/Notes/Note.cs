using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    public NoteData data { set;get; }
    
    public Vector3 startPos,endPos;
    public float noteDropTime = 0.21f;
    //public float speed = 0.1f;
    public abstract void Move();
    /*{
       
        else if (!isDestroyed)
        {
            isDestroyed = true;
            StartCoroutine(DestroyNote());
        }*/
        /*if (transform.position.x >= endPos.x)
        {
            transform.position += Vector3.left * speed;
        }
        else
        {
            transform.position = endPos;
        }
    }*/
    public abstract void Judge();
}
