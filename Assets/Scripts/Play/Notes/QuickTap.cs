using System.Collections;
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
    private bool animPlayed = false;

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
        if (!animPlayed)
        {
            text.text = tapCount.ToString();
        }
        if (tapCount == 0 && NoteController.isAutoPlay)
        {
            if (!animPlayed)
            {
                animPlayed = true;
                StartCoroutine(ExploreAnim());
            }
        }
    }
    private IEnumerator ReduceCount()
    {
        yield return new WaitForSeconds(NoteController.NoteSpeed);
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
                ShowJudge(JudgeType.LateGreat);
                Debug.Log(Data + "great");
            }
            else if (cnt - tapCount < cnt * 0.5)
            {
                NoteController.combo++;
                NoteController.good++;
                ShowJudge(JudgeType.LateGood);
                Debug.Log(Data + "good");
            }
            else
            {
                NoteController.combo = 0;
                NoteController.miss++;
                ShowJudge(JudgeType.Miss);
                Debug.Log(Data + "miss");
            }
        }
        Destroy(gameObject);
    }
    public void GrowBalloon()
    {
        
        Debug.Log("growBalloon");
        animScale *= 2f;
        transform.GetChild(0).transform.localScale = new Vector3(animScale.x, animScale.y,animScale.z);
        Debug.Log(transform.GetChild(0).transform.localScale);
    }    

    public IEnumerator ExploreAnim()
    {
        NoteController.combo++;
        transform.GetChild(1).GetComponent<TextMeshPro>().text = "";
        Destroy(transform.GetChild(0).GetChild(0).gameObject);
        ShowJudge(JudgeType.Perfect);
        transform.GetChild(0).GetComponent<Animator>().Play("balloon");
        yield return new WaitForSeconds(animExplore.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
        yield break;
    }
}
