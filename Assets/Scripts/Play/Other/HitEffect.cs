using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    void Start()
    {
		StartCoroutine(DestroyAnim());
    }
	public IEnumerator DestroyAnim()
	{
		yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
		Destroy(gameObject);
	}
}
