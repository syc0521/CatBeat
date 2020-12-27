using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public ResultInfo Info;

    public TextMesh[] text;
    public Text[] judgeDetail;
    public Text comboText;
    public Text nameText;
    public Text diffText;

    private void Start()
    {
        Info.score = 55555;//测试用代码
        StartCoroutine(ShowScore());
        ShowJudge();
    }

    private void ShowJudge()
    {
        judgeDetail[0].text = NoteController.perfect.ToString();
        judgeDetail[1].text = NoteController.great.ToString();
        judgeDetail[2].text = NoteController.good.ToString();
        judgeDetail[3].text = NoteController.miss.ToString();
        comboText.text = NoteController.maxCombo.ToString();
        diffText.text = ShowLevel();
    }

    private string ShowLevel()
    {
        var song = SongManager.songList.Find(item => item.Path == NoteController.path);
        switch (NoteController.diff)
        {
            case Diff.Easy:
                return "Easy Lv." + song.EasyLevel;
            case Diff.Normal:
                return "Normal Lv." + song.NormalLevel;
            case Diff.Hard:
                return "Hard Lv." + song.HardLevel;
        }
        return null;
    }
    /// <summary>
    /// 展示分数
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i <= Info.score; i++)
        {
            if (Info.score - i < 10)
            {
            }
            else if (i + 10000 < Info.score)
            {
                i += 10000;
            }
            else if (i + 5000 < Info.score)
            {
                i += 5000;
            }
            else if (i + 1000 < Info.score)
            {
                i += 1000;
            }
            else if (i + 100 < Info.score)
            {
                i += 100;
            }

            yield return new WaitForSeconds(0.01f);
            for (int j = 0; j < 5; j++)
            {
                text[j].text = GetNum(i, j);
            }
            Debug.Log(i);


        }
        yield break;
    }
    /// <summary>
    /// 引入二次函数曲线来更改数据的增长速度，先快后慢
    /// </summary>
    /// <param name="i"></param>

    /// <summary>
    /// 获得第K位的数字
    /// </summary>
    /// <param name="k"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    private string GetNum(int val, int k)
    {
        val /= (int)Mathf.Pow(10, k);
        return (val % 10).ToString();
    }

}