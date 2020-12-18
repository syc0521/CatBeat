using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject tap_R, tap_B, tap_P;
    public GameObject hold_R, hold_B, hold_P;
    public GameObject quickTap, slider, micInput;
    public Transform startPos, endPos;
    public List<NoteData> notes = new List<NoteData>();
    public float noteSpeed = 0.45f;
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
                CreateHold(note);
                break;
            case NoteType.QuickTap:
                break;
            case NoteType.Slider:
                break;
            case NoteType.MicInput:
                break;
        };
        /*Tap n;
        if (note.Information == 1)
        {
            n = Instantiate(tap_R, startPos.position, Quaternion.identity).GetComponent<Tap>();
            n.type = 1;
        }
        else if (note.Information == 2)
        {
            n = Instantiate(tap_B, startPos.position, Quaternion.identity).GetComponent<Tap>();
            n.type = 2;
        }
        else
        {
            n = Instantiate(tap_P, startPos.position, Quaternion.identity).GetComponent<Tap>();
            n.type = 3;
        }
        n.endPos = endPos.position;

        Debug.Log(note.Time);*/
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
        tap.data = note;
        tap.startPos = startPos.position;
        tap.endPos = endPos.position;
    }
    private void CreateHold(NoteData note)
    {
        Hold hold;
        if (note.Information == 1)
        {
            hold=Instantiate(hold_R, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        else if (note.Information == 2)
        {
            hold=Instantiate(hold_B, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        else
        {
            hold=Instantiate(hold_P, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        hold.data = note;
        hold.startPos = startPos.position;
        hold.endPos = endPos.position;
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
