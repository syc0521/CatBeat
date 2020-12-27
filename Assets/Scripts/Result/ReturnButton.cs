using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void OnPressed()
    {
        LoadingManager.nextScene = "Select";
        SceneManager.LoadScene("Loading");
    }
    public void OnRetryPressed()
    {
        LoadingManager.nextScene = "Play";
        SceneManager.LoadScene("Loading");
    }
}
