using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    public int startTime, endTime;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        float alpha = Utils.GetAlpha(startTime, endTime);
        lr.startColor = new Color(1.0f, 1.0f, 1.0f, alpha);
        lr.endColor = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
