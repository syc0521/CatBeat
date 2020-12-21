using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTap : Note
{
    [HideInInspector]
    public int tapCount = 0;
    private TextMesh text;
    public GameObject fx;

    void Start()
    {
        tapCount = Data.Information;
        text = transform.GetChild(1).GetComponent<TextMesh>();
        text.text = "";
        StartCoroutine(ReduceCount());
    }

    void Update()
    {
        if (tapCount == 0)
        {
            NoteController.combo++;
            Destroy(gameObject);
        }
    }
    private IEnumerator ReduceCount()
    {
        yield return new WaitForSeconds(NoteController.noteSpeed);
        do
        {
            yield return new WaitForSeconds(0.05f);
            tapCount--;
            text.text = tapCount.ToString();
            NoteController.score += (int)(NoteController.Multiplier * 15);
            Instantiate(fx);
        } while (tapCount > 0);
    }
}
