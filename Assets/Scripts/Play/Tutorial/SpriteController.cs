using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Text text;
    public int startTime, endTime;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        float alpha = Utils.GetAlpha(startTime, endTime);
        text.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
