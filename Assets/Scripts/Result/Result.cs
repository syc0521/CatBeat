using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public TextMeshPro scoreText;
    public Text[] judgeDetail;
    public Text comboText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI diffText;
    private Song song;
    public Sprite[] gradeSprite;
    public GameObject gradeObj;

    private void Start()
    {
        song = SongManager.songList.Find(item => item.Path == NoteController.path);
        StartCoroutine(ShowScore());
        ShowJudge();
    }
    private void ShowJudge()
    {
        int total = NoteController.perfect + NoteController.great + NoteController.good + NoteController.miss;
        int realScore = (int)(NoteController.perfect + NoteController.great * 0.8f + NoteController.good * 0.5f);
        float rate = realScore / (float)total;
        Grade grade = Utils.GetGrade(rate);
        gradeObj.GetComponent<SpriteRenderer>().sprite = gradeSprite[(int)grade];
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
    private IEnumerator ShowScore()
    {
        int score = NoteController.score;
        for (int i = 0; i <= score; i++)
        {
            if (score - i < 1)
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
            else if (i + 10 < score)
            {
                i += 10;
            }
            float waitSec = 0.025f;
            waitSec += 0.008f;
            yield return new WaitForSeconds(waitSec);
            scoreText.text = Utils.ConvertDigit(i);
        }
        yield break;
    }
    private void SetScore()
    {
        
    }

}