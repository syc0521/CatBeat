using UnityEngine;
using System.Collections;
public class MicInput : Note
{
    public GameObject fx;
    private float holdTime;
    private bool canInput = false;
    private bool isPerfect = false;
    public Animator micAnim;
    public GameObject shiny;
    private bool firstDestroy = true;
    private void Start()
    {
        moveTime = NoteController.NoteSpeed;
        micAnim = transform.GetComponent<Animator>();
    }
    public override void Update()
    {
        base.Update();
        if (NoteController.isAutoPlay)
        {
            AutoPlayMode();
        }
        else
        {
            UserPlayMode();
        }
    }
    private void UserPlayMode()
    {
       // Debug.Log(canInput);
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime - NoteController.goodTime * 1.5f)
        {
            canInput = true;
            if (MicrophoneController.realVolume >= 0.38f && canInput)
            {
                shiny.GetComponent<ParticleSystem>().Play();
               // Debug.Log("mic-taping");
                micAnim.Play("mic-taping");
                holdTime += Time.deltaTime;
                NoteController.score += (int)(NoteController.Multiplier * 15.0f);
            }
            if (holdTime > Data.Dur * 0.5f && !isPerfect)
            {
                isPerfect = true;
            }
            if (holdTime > Data.Dur * 0.8f)
            {
                canInput = false;
                if (firstDestroy)
                {
                    if (isPerfect)
                    {
                        NoteController.perfect++;
                        NoteController.combo++;
                        ShowJudge(JudgeType.Perfect);
                        ShowJudgeEffect();
                        Instantiate(fx);
                    }
                    else
                    {
                        NoteController.miss++;
                        NoteController.combo = 0;
                        ShowJudge(JudgeType.Miss);
                    }
                    firstDestroy = false;
                }
                if (Data.Index < NoteController.noteCount - 1)
                {
                    NoteController.notes[Data.Index + 1].CanJudge = true;
                }
                Instantiate(shiny, endPos, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            if (firstDestroy)
            {
                if (isPerfect)
                {
                    NoteController.perfect++;
                    NoteController.combo++;
                    ShowJudge(JudgeType.Perfect);
                    ShowJudgeEffect();
                    Instantiate(fx);
                }
                else
                {
                    NoteController.miss++;
                    NoteController.combo = 0;
                    ShowJudge(JudgeType.Miss);
                }
                if (Data.Index < NoteController.noteCount - 1)
                {
                    NoteController.notes[Data.Index + 1].CanJudge = true;
                }
                firstDestroy = false;
                Instantiate(shiny, endPos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void AutoPlayMode()
    {
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime)
        {
            micAnim.Play("mic-taping");
            //transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            NoteController.score += (int)(NoteController.Multiplier * 15.0f);
        }
        if (Time.timeSinceLevelLoad >= Data.Time + moveTime + Data.Dur * 0.8f)
        {
            micAnim.Play("stop");
            NoteController.combo++;
            Instantiate(fx);
            ShowJudge(JudgeType.Perfect);
            ShowJudgeEffect();
            Instantiate(shiny,endPos,Quaternion.identity);
            Destroy(gameObject);
        }
    }
   /* public IEnumerator DestroyMic()
    {
        if (firstDestroy)
        {
            NoteController.perfect++;
            NoteController.combo++;
            ShowJudge(JudgeType.Perfect);
            firstDestroy = false;
            Debug.Log("MicAnimPlay");
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }*/
}
