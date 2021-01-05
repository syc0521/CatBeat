using UnityEngine;

public class SpriteController : MonoBehaviour
{
    private SpriteRenderer sr;
    public int startTime, endTime;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alpha = Utils.GetAlpha(startTime, endTime);
        sr.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
