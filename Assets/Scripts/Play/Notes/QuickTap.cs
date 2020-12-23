using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTap : Note
{
    [HideInInspector]
    public int tapCount = 0;
    private TextMesh text;
    public GameObject fx;
    public float tapTime;
    private int cnt;

    void Start()
    {
        cnt = tapCount;
        tapCount = Data.Information;
        tapTime = tapCount * 0.1f;
        text = transform.GetChild(1).GetComponent<TextMesh>();
        text.text = "";
        if (NoteController.isAutoPlay)
        {
            StartCoroutine(ReduceCount());
        }
        else
        {
            StartCoroutine(DestroyNote());
        }
    }

    void Update()
    {
        text.text = tapCount.ToString();
        if (tapCount == 0 && NoteController.isAutoPlay)
        {
            NoteController.combo++;
            Destroy(gameObject);
        }
    }
    private IEnumerator ReduceCount()
    {
        while (tapCount > 0)
        {
            tapCount--;
            text.text = tapCount.ToString();
            NoteController.score += (int)(NoteController.Multiplier * 25.0f);
            Instantiate(fx);
        } while (tapCount > 0);
        yield break;
    }
    private IEnumerator DestroyNote()
    {
        yield return new WaitForSeconds(tapTime + moveTime);
        if (Data.Index < NoteController.noteCount - 1)
        {
            NoteController.notes[Data.Index + 1].CanJudge = true;
        }
        if (tapCount > 0)
        {
            if (cnt - tapCount < cnt * 0.2)
            {
                NoteController.combo++;
                NoteController.great++;
                Debug.Log(Data + "great");
            }
            else if (cnt - tapCount < cnt * 0.5)
            {
                NoteController.combo++;
                NoteController.good++;
                Debug.Log(Data + "good");
            }
            else
            {
                NoteController.combo = 0;
                NoteController.miss++;
                Debug.Log(Data + "miss");
            }
        }
        Destroy(gameObject);
    }
}
