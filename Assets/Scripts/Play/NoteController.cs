using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum JudgeType { Perfect = 0, EarlyGreat = 1, LateGreat = 2, EarlyGood = 3, LateGood = 4, Miss = -1, Default = -2 };

public class NoteController : MonoBehaviour
{
    public GameObject tap_R, tap_B, tap_P;
    public GameObject hold_R, hold_B, hold_P;
    public GameObject quickTap, slider, micInput;
    public Transform startPos, endPos;
    public static List<NoteData> notes = new List<NoteData>();
    public static List<Note> noteObjs = new List<Note>();
    public static float noteSpeed = 1.15f;
    public static int combo;
    public TextMesh comboText;
    public TextMesh scoreText;
    public static int score;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;
    public static int perfect, great, good, miss;
    public static int noteCount;
    public static bool isAutoPlay = true;

    public static float Multiplier => 1.00f + combo / 50 * 0.05f;
    void Start()
    {
        score = 0; combo = 0;
        perfect = 0; great = 0; good = 0; miss = 0;
        foreach (NoteData note in notes)
        {
            StartCoroutine(CreateNote(note));
        }
    }
    private void Update()
    {
        comboText.text = combo.ToString();
        scoreText.text = score.ToString();
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
        noteObjs.Add(noteObj);
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
        MicInput mic = Instantiate(micInput, startPos.position, Quaternion.identity).GetComponent<MicInput>();
        return mic;
    }
}
