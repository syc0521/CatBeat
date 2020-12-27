using System.Collections;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    public int startIndex;
    void Start()
    {
        GetComponent<Animator>().Play("Stop");
        StartCoroutine(PlayAnimation());
    }
    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(startIndex * 0.18f);
        GetComponent<Animator>().Play("LoadingDot");
    }
}
