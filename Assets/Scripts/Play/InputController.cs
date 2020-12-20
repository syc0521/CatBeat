using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum JudgeType { Perfect = 0, EarlyGreat = 1, LateGreat = 2, EarlyGood = 3, LateGood = 4, Miss = -1 };
public class InputController : MonoBehaviour
{
    Input InputControls;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;

    private void Awake()
    {
        InputControls = new Input();

        InputControls.PlayController.Tap_Red.performed += ctx => DestroyTapRed();
    }

    private void DestroyTapRed()
    {

    }

    void OnEnable()
    {
        InputControls.PlayController.Enable();
    }

}
