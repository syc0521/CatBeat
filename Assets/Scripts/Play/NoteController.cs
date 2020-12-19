using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject tap_R, tap_B, tap_P;
    public GameObject hold_R_holdObj,hold_R_start, hold_R_hold, hold_R_end;
    public GameObject hold_B, hold_P;
    public GameObject quickTap, slider, micInput;
    public Transform startPos, endPos;
    public List<NoteData> notes = new List<NoteData>();
    public static float noteSpeed = 0.65f;
    void Start()
    {
        foreach (NoteData note in notes)
        {
            StartCoroutine(CreateNote(note));
        }
    }

    void Update()
    {
        
    }
    private IEnumerator CreateNote(NoteData note)
    {
        yield return new WaitForSeconds(note.Time);
        switch (note.Type)
        {
            case NoteType.Tap:
                CreateTap(note);
                break;
            case NoteType.Hold:
                StartCoroutine(CreateHold(note));
                break;
            case NoteType.QuickTap:
                break;
            case NoteType.Slider:
                break;
            case NoteType.MicInput:
                break;
        };
    }
    private void CreateTap(NoteData note)
    {
        Tap tap;
        if (note.Information == 1)
        {
            tap = Instantiate(tap_R, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        else if (note.Information == 2)
        {
            tap = Instantiate(tap_B, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        else
        {
            tap = Instantiate(tap_P, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        tap.Data = note;
        tap.startPos = startPos.position;
        tap.endPos = endPos.position;
        tap.type = note.Information;
    }
    //思路：先生成start，隔dur秒再生成end，hold的长度为start与end之间的距离



    private IEnumerator CreateHold(NoteData note)
    { 
        Hold holdNote;//
        GameObject holdObj,start,hold,end;

        if (note.Information == 1)
        {
            start = Instantiate(hold_R_start, startPos.position, Quaternion.identity);
            yield return new WaitForSeconds(note.Dur);
            end = Instantiate(hold_R_end, startPos.position, Quaternion.identity);
            hold = Instantiate(hold_R_end, start.transform.position, Quaternion.identity);

            float scaleX = (end.transform.position.x-start.transform.position.x) / 
                (hold.GetComponent<SpriteRenderer>().bounds.size.x);
            hold.GetComponent<Transform>().localScale = new Vector3(scaleX,1,1);
            holdObj = Instantiate(hold_R_holdObj);

            holdNote=holdObj.GetComponent<Hold>();
            start.transform.SetParent(holdObj.transform);
            end.transform.SetParent(holdObj.transform);
            hold.transform.SetParent(holdObj.transform);

        }
        else if (note.Information == 2)
        {
            start = Instantiate(hold_R_start, startPos.position, Quaternion.identity);
            yield return new WaitForSeconds(note.Dur);
            end = Instantiate(hold_R_end, startPos.position, Quaternion.identity);
            hold = Instantiate(hold_R_end, start.transform.position, Quaternion.identity);

            float scaleX = (end.transform.position.x - start.transform.position.x) /
                (hold.GetComponent<SpriteRenderer>().bounds.size.x);
            hold.GetComponent<Transform>().localScale = new Vector3(scaleX, 1, 1);
            holdObj = Instantiate(hold_R_holdObj);

            holdNote = holdObj.GetComponent<Hold>();
            start.transform.SetParent(holdObj.transform);
            end.transform.SetParent(holdObj.transform);
        }
        else
        {
            start = Instantiate(hold_R_start, startPos.position, Quaternion.identity);
            yield return new WaitForSeconds(note.Dur);
            end = Instantiate(hold_R_end, startPos.position, Quaternion.identity);
            hold = Instantiate(hold_R_end, start.transform.position, Quaternion.identity);

            float scaleX = (end.transform.position.x - start.transform.position.x) /
                (hold.GetComponent<SpriteRenderer>().bounds.size.x);
            hold.GetComponent<Transform>().localScale = new Vector3(scaleX, 1, 1);
            holdObj = Instantiate(hold_R_holdObj);

            holdNote = holdObj.GetComponent<Hold>();
            start.transform.SetParent(holdObj.transform);
            end.transform.SetParent(holdObj.transform);
        }
        holdNote.Data = note;
        holdNote.startPos = startPos.position;
        holdNote.endPos = endPos.position;
        yield  break;
    }
    private void CreateQuickTap(NoteData note)
    {

    }
    private void CreateSlider(NoteData note)
    {

    }
    private void CreateMicInput(NoteData note)
    {

    }
}
