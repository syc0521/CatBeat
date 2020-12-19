using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Input InputControls;
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
