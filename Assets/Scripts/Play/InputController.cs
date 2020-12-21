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
        controls.PlayController.Tap_Blue.performed += DestroyBlueTap;
        controls.PlayController.Tap_Purple.performed += DestroyPurpleTap;
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
            if (note.Index < NoteController.noteCount)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            note.CanJudge = false;
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
    private void DestroyBlueTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime
                                                  && item.Information == 2 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            note.CanJudge = false;
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
    private void DestroyPurpleTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime
                                                  && item.Information == 2 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            note.CanJudge = false;
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

    private JudgeType JudgeTap(NoteData note)
    {
        float sceneTime = Time.timeSinceLevelLoad;
        float exactTime = note.Time + NoteController.noteSpeed + 0.045f;
        var perfectTime = NoteController.perfectTime;
        var greatTime = NoteController.greatTime;
        var goodTime = NoteController.goodTime;
        if (note.CanJudge)
        {
            if (sceneTime <= exactTime + perfectTime && sceneTime > exactTime - perfectTime)
            {
                Debug.Log(note + "perfect");
                NoteController.perfect++;
                return JudgeType.Perfect;
            }
            else if (sceneTime < exactTime + greatTime && sceneTime > exactTime + perfectTime)
            {
                Debug.Log(note + "Lgreat");
                NoteController.great++;
                return JudgeType.LateGreat;
            }
            else if (sceneTime > exactTime - greatTime && sceneTime < exactTime - perfectTime)
            {
                Debug.Log(note + "Egreat");
                NoteController.great++;
                return JudgeType.EarlyGreat;
            }
            else if (sceneTime < exactTime + goodTime - 0.05f && sceneTime > exactTime + greatTime)
            {
                Debug.Log(note + "Lgood");
                NoteController.good++;
                return JudgeType.LateGood;
            }
            else if (sceneTime > exactTime - goodTime && sceneTime < exactTime - greatTime)
            {
                Debug.Log(note + "Egood");
                NoteController.good++;
                return JudgeType.EarlyGood;
            }
            else if (sceneTime < exactTime - goodTime)
            {
                return JudgeType.Default;
            }
            else if (sceneTime > exactTime + goodTime)
            {
                return JudgeType.Miss;
            }
        }
        return JudgeType.Default;
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