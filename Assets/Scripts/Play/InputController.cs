using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputController : MonoBehaviour
{
    //Input思路：在这里面更改Data的canJudge，和canDestroy，如果canDestroy为true的话，销毁这个物体
    InputMaster controls;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;

    private void Awake()
    {
        controls = new InputMaster();
        controls.PlayController.Tap_Red.performed += DestroyRedTap;
        controls.PlayController.Tap_Blue.performed += ctx => Debug.Log("DestroyBlueTap");
    }

    private void DestroyRedTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime 
                                                  && item.Time < time + goodTime 
                                                  && item.Information == 1 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            note.CanJudge = false;
            if (note.Index < NoteController.noteCount)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            Debug.Log(note + "destroy");
            try
            {
                Destroy(noteObj.gameObject);
            }
            catch (Exception)
            {
                Debug.LogError(note + "destroyWrong");
            }
        }
    }


    private void DestroyBlueTap()
    {
        Debug.Log("DestroyBlueTap");
        /*foreach (NoteData noteData in noteList)
        {
            if (noteData.CanJudge == true && noteData.Type == NoteType.Tap && noteData.Information == 2)
            {
                noteData.CanDestroy = true;
            }
        }*/
    }

    void OnEnable()
    {
        controls.PlayController.Enable();
    }
    private void OnDisable()
    {
        controls.PlayController.Disable();
    }

}