using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputController : MonoBehaviour
{
    //Input思路：在这里面更改Data的canJudge，和canDestroy，如果canDestroy为true的话，销毁这个物体
    InputMaster controls;
    public List<NoteData> noteList = new List<NoteData>();

    InputMaster InputControls;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;

    private void Awake()
    {
        controls = new InputMaster();

        controls.PlayController.Tap_Red.performed += ctx => Debug.Log("DestroyRedTap");
        controls.PlayController.Tap_Blue.performed += ctx => Debug.Log("DestroyBlueTap");
    }

    private void DestroyRedTap()
    {
        Debug.Log("DestroyRedTap");
        /*foreach (NoteData noteData in noteList)
        {
            if (noteData.CanJudge == true&&noteData.Type==NoteType.Tap&&noteData.Information==1)
            {
                noteData.CanDestroy = true;
            }
        }*/
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
    /*private void GetFirstNotes()
    {
        for (int i = 0; i < 5; i++)
        {
            int firstIndex = noteList.FindIndex(
                delegate (NoteData note1)
                {
                    return note1.Pos == i;
                });
            if (firstIndex != -1)
            {
                noteList[firstIndex].CanJudge = true;
            }
        }
    }*/

    void OnEnable()
    {
        controls.PlayController.Enable();
    }
    private void OnDisable()
    {
        controls.PlayController.Disable();
    }

}