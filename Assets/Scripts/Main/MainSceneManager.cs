using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private static bool input;
    private void Awake()
    {
        Utils.GetList();
        GetPrefs();
    }
    private void Start()
    {
        if (!input)
        {
            InputController.controls = new InputMaster();
            input = true;
        }
    }
    private void Update()
    {
        Utils.QuitProgram();
    }
    private void GetPrefs()
    {
        if (!File.Exists(Utils.filePath))
        {
            Utils.InitializeSave(Utils.filePath);
        }
        else
        {
            Utils.GetSave();
        }
    }
}
