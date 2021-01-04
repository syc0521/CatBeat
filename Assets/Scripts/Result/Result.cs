using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    private Grade grade;

    private void Start()
    {
        song = SongManager.songList.Find(item => item.Path == NoteController.path);
        StartCoroutine(ShowScore());
        ShowJudge();
        SetScore();
    }
    private void ShowJudge()
    {
        int total = NoteController.noteCount * 3;
        int realScore = NoteController.perfect * 3 + NoteController.great * 2 + NoteController.good;
        float rate = realScore / (float)total;
        grade = Utils.GetGrade(rate);
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
        for (int i = 0; i < score; i++)
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
        SaveData save = Utils.save;
        SaveData.SongSave songSave = save.Songs.Find(item => item.path.Equals(NoteController.path));
        if (songSave != null)
        {
            if (NoteController.score > songSave.score[(int)NoteController.diff])
            {
                songSave.score[(int)NoteController.diff] = NoteController.score;
            }
            if ((int)grade < (int)songSave.grade[(int)NoteController.diff])
            {
                songSave.grade[(int)NoteController.diff] = grade;
            }
        }
        int sCount = 0;
        save.Songs.ForEach(song => sCount += song.grade.Where(grade => grade.Equals(Grade.S)).Count());//获取S等级数量
        MainSceneManager.ending = sCount >= 2;
        Utils.save.SystemSettings = new SaveData.Settings
        {
            isAutoPlay = Utils.save.SystemSettings.isAutoPlay,
            speed = Utils.save.SystemSettings.speed,
            hitVol = Utils.save.SystemSettings.hitVol,
            ending = MainSceneManager.ending,
            secret = Utils.save.SystemSettings.secret
        };
        Utils.SavePrefs();
    }

}