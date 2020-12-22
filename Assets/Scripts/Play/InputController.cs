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
    public GameObject R_FX;
    public GameObject B_FX;
    private QuickTap currentQuickTap;
    Keyboard gp;

    private void Awake()
    {
        controls = new InputMaster();
        if (!NoteController.isAutoPlay)
        {
            controls.PlayController.Tap_Red.started += DestroyRedTap;
            controls.PlayController.Tap_Red_Right.started += DestroyRedTap;
            controls.PlayController.Tap_Blue.started += DestroyBlueTap;
            controls.PlayController.Tap_Blue_Right.started += DestroyBlueTap;
            controls.PlayController.Tap_Purple.started += DestroyPurpleTap;
            controls.PlayController.Tap_Red.started += DestroyQuickTap;
            controls.PlayController.Tap_Blue.started += DestroyQuickTap;
            controls.PlayController.Tap_Red_Right.started += DestroyQuickTap;
            controls.PlayController.Tap_Blue_Right.started += DestroyQuickTap;
            controls.PlayController.Tap_Red.started += DestroyRedHold;
            controls.PlayController.Tap_Blue.started += DestroyBlueHold;
        }
    }
    private void DestroyRedTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime 
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 1 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(R_FX);
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
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 2 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(B_FX);
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
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 3 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(R_FX);
            Instantiate(B_FX);
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
    private void DestroyRedHold(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Hold)
                                                  && item.Information == 1 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(R_FX);
            try
            {
                //Destroy(noteObj.gameObject);
            }
            catch (Exception)
            {
                Debug.LogError(note + "destroyWrong");
            }
        }
    }
    private void DestroyBlueHold(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Hold)
                                                  && item.Information == 2 && item.CanJudge && !item.CanDestroy);
        if (note != null && !note.CanDestroy)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            note.CanDestroy = true;
            if (note.Index < NoteController.noteCount - 1)
            {
                NoteController.notes[note.Index + 1].CanJudge = true;
            }
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(B_FX);
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

    private void DestroyQuickTap(InputAction.CallbackContext obj)
    {
        if (currentQuickTap == null)
        {
            var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
            var note = NoteController.notes.Find(item => item.Time > time - goodTime * 1.5
                                                      && item.Time < time + goodTime * 1.5 && item.Type.Equals(NoteType.QuickTap)
                                                      && item.CanJudge && !item.CanDestroy);
            if (note != null)
            {
                QuickTap noteObj = NoteController.noteObjs[note.Index].GetComponent<QuickTap>();
                currentQuickTap = noteObj;
                Debug.Log(currentQuickTap.Data);
                currentQuickTap.tapCount--;
                NoteController.score += (int)(NoteController.Multiplier * 25.0f);
                Instantiate(R_FX);
                note.CanJudge = false;
            }
        }
        else
        {
            Debug.Log("count--");
            currentQuickTap.tapCount--;
            Instantiate(R_FX);
            if (currentQuickTap.tapCount <= 0)
            {
                currentQuickTap.Data.CanDestroy = true;
                if (currentQuickTap.Data.Index < NoteController.noteCount - 1)
                {
                    NoteController.notes[currentQuickTap.Data.Index + 1].CanJudge = true;
                }
                Destroy(currentQuickTap.gameObject);
                currentQuickTap = null;
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
            else if (sceneTime < exactTime + goodTime - 0.02f && sceneTime > exactTime + greatTime)
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
    private void TapJudgeFinished(JudgeType judgeType)
    {
        switch (judgeType)
        {
            case JudgeType.Perfect:
                NoteController.combo++;
                NoteController.perfect++;
                NoteController.score += (int)(NoteController.Multiplier * 100.0f);
                break;
            case JudgeType.EarlyGreat:
                NoteController.combo++;
                NoteController.great++;
                NoteController.score += (int)(NoteController.Multiplier * 80.0f);
                break;
            case JudgeType.LateGreat:
                NoteController.combo++;
                NoteController.great++;
                NoteController.score += (int)(NoteController.Multiplier * 80.0f);
                break;
            case JudgeType.EarlyGood:
                NoteController.combo++;
                NoteController.good++;
                NoteController.score += (int)(NoteController.Multiplier * 50.0f);
                break;
            case JudgeType.LateGood:
                NoteController.combo++;
                NoteController.good++;
                NoteController.score += (int)(NoteController.Multiplier * 50.0f);
                break;
            case JudgeType.Miss:
                NoteController.miss++;
                NoteController.combo = 0;
                break;
        }
    }
}