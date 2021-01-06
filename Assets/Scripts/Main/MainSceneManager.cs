using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.F12))//重新建档
        {
            Utils.InitializeSave(Utils.filePath);
            LoadingManager.nextScene = "Main";
            SceneManager.LoadScene("Loading");
        }
        Utils.QuitProgram();
        if (Input.GetKeyDown(KeyCode.F5))//歌曲全解
        {
            Utils.SaveUnlockPrefs();
            LoadingManager.nextScene = "Main";
            SceneManager.LoadScene("Loading");
        }
    }
}
