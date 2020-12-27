using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputController : MonoBehaviour
{
    public static InputMaster controls;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;
    public GameObject R_FX;
    public GameObject B_FX;
    private QuickTap currentQuickTap;

    private void Start()
    {
        controls.PlayController.Enable();
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
            controls.PlayController.Tap_Red_Right.started += DestroyRedHold;
            controls.PlayController.Tap_Blue_Right.started += DestroyBlueHold;
        }
    }
    private void DestroyRedTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime 
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 1 && item.CanJudge);
        if (note != null)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            StartCoroutine(NoteController.ModifyNote(note));
            note.CanJudge = false;
            Instantiate(R_FX);
            Destroy(noteObj.gameObject);
        }
    }
    private void DestroyBlueTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 2 && item.CanJudge);
        if (note != null)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            JudgeType judgeType = JudgeTap(note);
            StartCoroutine(NoteController.ModifyNote(note));
            TapJudgeFinished(judgeType);
            note.CanJudge = false;
            Instantiate(B_FX);
            Destroy(noteObj.gameObject);
        }
    }
    private void DestroyPurpleTap(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Tap)
                                                  && item.Information == 3 && item.CanJudge);
        if (note != null)
        {
            var noteObj = NoteController.noteObjs[note.Index];
            JudgeType judgeType = JudgeTap(note);
            TapJudgeFinished(judgeType);
            StartCoroutine(NoteController.ModifyNote(note));
            note.CanJudge = false;
            Instantiate(R_FX);
            Instantiate(B_FX);
            Destroy(noteObj.gameObject);
        }
    }
    private void DestroyRedHold(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                    && item.Time < time + goodTime && item.Type.Equals(NoteType.Hold)
                                                    && item.Information == 1 && item.CanJudge);
        if (note != null)
        {
            Hold noteObj = NoteController.noteObjs[note.Index].GetComponent<Hold>();
            JudgeType judgeType = JudgeTap(note);
            noteObj.isHold = true;
            noteObj.firstType = judgeType;
            note.CanJudge = false;
            Instantiate(R_FX);
        }
    }
    private void DestroyBlueHold(InputAction.CallbackContext obj)
    {
        var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
        var note = NoteController.notes.Find(item => item.Time > time - goodTime
                                                  && item.Time < time + goodTime && item.Type.Equals(NoteType.Hold)
                                                  && item.Information == 2 && item.CanJudge);
        if (note != null)
        {
            Hold noteObj = NoteController.noteObjs[note.Index].GetComponent<Hold>();
            JudgeType judgeType = JudgeTap(note);
            noteObj.isHold = true;
            noteObj.firstType = judgeType;
            note.CanJudge = false;
            Instantiate(B_FX);
        }
    }

    private void DestroyQuickTap(InputAction.CallbackContext obj)
    {
        if (currentQuickTap == null)
        {
            var time = Time.timeSinceLevelLoad - NoteController.noteSpeed;
            var note = NoteController.notes.Find(item => item.Time > time - goodTime * 1.5
                                                      && item.Time < time + goodTime * 1.5 && item.Type.Equals(NoteType.QuickTap)
                                                      && item.CanJudge);
            if (note != null)
            {
                QuickTap noteObj = NoteController.noteObjs[note.Index].GetComponent<QuickTap>();
                currentQuickTap = noteObj;
                currentQuickTap.tapCount--;
                NoteController.score += (int)(NoteController.Multiplier * 25.0f);
                Instantiate(R_FX);
                note.CanJudge = false;
            }
        }
        else
        {
            currentQuickTap.tapCount--;
            Instantiate(R_FX);
            if (currentQuickTap.tapCount <= 0)
            {
                NoteController.score += (int)(NoteController.Multiplier * 25.0f);
                NoteController.combo++;
                StartCoroutine(NoteController.ModifyNote(currentQuickTap.Data));
                currentQuickTap.OnNoteDestroy();
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
