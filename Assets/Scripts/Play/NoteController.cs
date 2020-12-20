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
    public static int combo;
    void Start()
    {
        combo = 0;
        foreach (NoteData note in notes)
        {
            StartCoroutine(CreateNote(note));
        }
    }

    private IEnumerator CreateNote(NoteData note)
    {
        yield return new WaitForSeconds(note.Time);
        Note noteObj = null;
        switch (note.Type)
        {
            case NoteType.Tap:
                noteObj = CreateTap(note);
                break;
            case NoteType.Hold:
                noteObj = CreateHold(note);
                break;
            case NoteType.QuickTap:
                noteObj = CreateQuickTap(note);
                break;
            case NoteType.Slider:
                noteObj = CreateSlider(note);
                break;
            case NoteType.MicInput:
                noteObj = CreateMicInput(note);
                break;
        };
        noteObj.Data = note;
        noteObj.startPos = startPos.position;
        noteObj.endPos = endPos.position;
    }
    private Note CreateTap(NoteData note)
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
        return tap;
    }
    private Note CreateHold(NoteData note)
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
        return hold;
    }
    private Note CreateQuickTap(NoteData note)
    {
        QuickTap qtap = Instantiate(quickTap, startPos.position, Quaternion.identity).GetComponent<QuickTap>();
        return qtap;
    }
    private Note CreateSlider(NoteData note)
    {
        Slider sli = Instantiate(slider, startPos.position, Quaternion.identity).GetComponent<Slider>();
        return sli;
    }
    private Note CreateMicInput(NoteData note)
    {
        //MicInput mic = Instantiate(micInput, startPos.position, Quaternion.identity).GetComponent<MicInput>();
        //return mic;
        return null;
    }
}
