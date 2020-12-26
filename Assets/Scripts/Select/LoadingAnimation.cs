using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LoadingAnimation : MonoBehaviour
{
    public int startIndex;
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }
    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(startIndex * 0.2f);
        GetComponent<PlayableDirector>().Play();
    }
}
