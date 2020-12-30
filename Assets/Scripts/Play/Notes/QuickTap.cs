﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class QuickTap : Note
{
    [HideInInspector]
    public int tapCount = 0;
    private TextMeshPro text;
    public GameObject fx;
    [HideInInspector]
    public float tapTime;
    private int cnt;

    public Vector3 animScale;
    public Animator animExplore;

    void Start()
    {
        cnt = tapCount;
        tapCount = Data.Information;
        tapTime = tapCount * 0.1f;
        text = transform.GetChild(1).GetComponent<TextMeshPro>();
        animScale = transform.GetChild(0).transform.localScale;
       
        animExplore = transform.GetChild(0).GetComponent<Animator>();
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

    public override void Update()
    {
        base.Update();
        text.text = tapCount.ToString();
        if (tapCount == 0 && NoteController.isAutoPlay)
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
    public void growBalloon()
    {
        
        Debug.Log("growBalloon");
        animScale *= 2f;
        Debug.Log("animScale" + animScale);
    }    
    public void exploreAnim()
    {
        animExplore.SetBool("canExplore", true);
        Debug.Log(animExplore.GetBool("canExplore"));
    }
}
