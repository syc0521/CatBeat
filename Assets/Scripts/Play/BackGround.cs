using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Sprite sprite;
    private Vector3 startPos;
    float startX;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        startX = sprite.bounds.extents.x * transform.localScale.x - 0.01f;
        startPos = new Vector3(startX * 2, transform.position.y);
        Debug.Log(startPos);
    }

    void Update()
    {
        transform.Translate(Vector3.left * 0.01f);
        if (transform.position.x <= -startX * 2)
        {
            transform.position = startPos;
        }
    }
}
