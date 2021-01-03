using System.IO;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private static bool input;
    public static bool secret;
    public static bool ending;
    private void Start()
    {
        if (!input)
        {
            Utils.GetList();
            InputController.controls = new InputMaster();
            input = true;
        }
        Utils.GetPrefs();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Utils.InitializeSave(Utils.filePath);
        }
        Utils.QuitProgram();
    }
}
