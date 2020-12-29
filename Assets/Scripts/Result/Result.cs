using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public ResultInfo Info;
    public TextMeshPro scoreText;
    public Text[] judgeDetail;
    public Text comboText;
    public Text nameText;
    public Text diffText;
    private Song song;

    private void Start()
    {
        song = SongManager.songList.Find(item => item.Path == NoteController.path);
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
        nameText.text = song.Name;
        diffText.text = ShowLevel();
    }

    private string ShowLevel()
    {
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
    private IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(0.5f);
        int score = NoteController.score;
        for (int i = 0; i <= score; i++)
        {
            if (score - i < 10)
            {
                i++;
            }
            else if (i + 10000 < score)
            {
                i += 10000;
            }
            else if (i + 5000 < score)
            {
                i += 5000;
            }
            else if (i + 1000 < score)
            {
                i += 1000;
            }
            else if (i + 100 < score)
            {
                i += 100;
            }
            float waitSec = 0.025f;
            waitSec += 0.01f;
            yield return new WaitForSeconds(waitSec);
            scoreText.text = Utils.ConvertDigit(i);
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
    private int GetNum(int val, int k)
    {
        val /= (int)Mathf.Pow(10, k);
        return (val % 10);
    }

}