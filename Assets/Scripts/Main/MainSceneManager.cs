using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private static bool input;
    private void Start()
    {
        if (!input)
        {
            InputController.controls = new InputMaster();
            input = true;
        }
    }
}
