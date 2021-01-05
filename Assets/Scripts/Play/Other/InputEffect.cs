using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEffect : MonoBehaviour
{
    public GameObject B_L, B_R, R_L, R_R;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            B_L.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            B_L.SetActive(false);
        }
        if (Input.GetKey(KeyCode.K))
        {
            B_R.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            B_R.SetActive(false);
        }
        if (Input.GetKey(KeyCode.F))
        {
            R_L.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            R_L.SetActive(false);   
        }
        if (Input.GetKey(KeyCode.J))
        {
            R_R.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            R_R.SetActive(false);
        }
    }
}
