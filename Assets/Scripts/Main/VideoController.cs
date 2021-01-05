using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeScene());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadingManager.nextScene = "Main";
            SceneManager.LoadScene("Loading");
        }
    }
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds((float)GetComponent<VideoPlayer>().clip.length + 0.5f);
        LoadingManager.nextScene = "Main";
        SceneManager.LoadScene("Loading");
    }
}
