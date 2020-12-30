using UnityEditor;
using UnityEngine;

public class Utils : MonoBehaviour
{
	public static float Lerp(float time, float timeRangeL, float timeRangeR, float posRangeL, float posRangeR)
	{
		return Mathf.LerpUnclamped(posRangeL, posRangeR, (time - timeRangeL) / (timeRangeR - timeRangeL));
    }
    public static Grade GetGrade(float rate)
    {
        if (rate >= 0.9f)
        {
            return Grade.S;
        }
        else if (rate >= 0.8f)
        {
            return Grade.A;
        }
        else if (rate >= 0.7f)
        {
            return Grade.B;
        }
        else if (rate >= 0.5f)
        {
            return Grade.C;
        }
        else
        {
            return Grade.D;
        }
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
    public static void QuitProgram()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else   
            Application.Quit();
#endif
        }
    }
}

