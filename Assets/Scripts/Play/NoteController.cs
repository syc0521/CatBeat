using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject tap_R, tap_B, tap_P;
    public GameObject hold_R, hold_B, hold_P;
    public GameObject quickTap, slider, micInput;
    public Transform startPos, endPos;
    public List<NoteData> notes;
    void Start()
    {
        StartCoroutine(CreateNote());
    }

    void Update()
    {
        
    }
    private IEnumerator CreateNote()
    {
        foreach (NoteData note in notes)
        {
            yield return new WaitForSeconds(note.Time);
            switch (note.Type)
            {
                case NoteType.Tap:
                    break;
                case NoteType.Hold:
                    break;
                case NoteType.QuickTap:
                    break;
                case NoteType.Slider:
                    break;
                case NoteType.MicInput:
                    break;
            }
            if (note.Information == 1)
            {
                Instantiate(tap_R, startPos.position, Quaternion.identity);
            }
            else if (note.Information == 2)
            {
                Instantiate(tap_B, startPos.position, Quaternion.identity);
            }
            else if (note.Information == 3)
            {
                Instantiate(tap_P, startPos.position, Quaternion.identity);
            }
            Debug.Log(note.Time);
        }

        yield break;
    }
}
