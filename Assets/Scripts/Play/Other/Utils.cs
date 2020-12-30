using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
	public static float Lerp(float time, float timeRangeL, float timeRangeR, float posRangeL, float posRangeR)
	{
		return Mathf.LerpUnclamped(posRangeL, posRangeR, (time - timeRangeL) / (timeRangeR - timeRangeL));
	}
    public static string ConvertDigit(int num)
    {
        string tmp = num.ToString();
        string result = "";
        foreach (var c in tmp)
        {
            result += "<sprite=" + c + ">";
        }
        return result;
    }
}

