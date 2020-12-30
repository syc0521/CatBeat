using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeText : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyThis());
    }
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
