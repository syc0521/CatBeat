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
    public static float noteSpeed = 1.05f;
    void Start()
    {
        foreach (NoteData note in notes)
        {
            StartCoroutine(CreateNote(note));
        }
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
                CreateQuickTap(note);
                break;
            case NoteType.Slider:
                CreateSlider(note);
                break;
            case NoteType.MicInput:
                CreateMicInput(note);
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
    private void CreateHold(NoteData note)
    {
        Hold hold;
        if (note.Information == 1)
        {
            hold = Instantiate(hold_R, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        else if (note.Information == 2)
        {
            hold = Instantiate(hold_B, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        else
        {
            hold = Instantiate(hold_P, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        hold.Data = note;
        hold.startPos = startPos.position;
        hold.endPos = endPos.position;
        hold.type = note.Information;
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
