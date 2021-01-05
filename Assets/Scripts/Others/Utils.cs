using LitJson;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class Utils : MonoBehaviour
{
    public static SaveData save;
    public static readonly string filePath = Application.persistentDataPath + "/save.json";
    public static void SavePrefs()
    {
        var jsonStr = JsonMapper.ToJson(save);
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(jsonStr);
        sw.Close();
        sw.Dispose();
    }
    public static void GetSave()
    {
        StreamReader sr = new StreamReader(filePath);
        save = JsonMapper.ToObject<SaveData>(sr.ReadToEnd());
        int sCount = 0;
        foreach (var song in SongManager.songList)
        {
            var current = save.Songs.Find(item => item.path.Equals(song.Path));
            if (current != null)
            {
                song.GradeLevel = (Grade[])current.grade.Clone();
                sCount += (current.grade.Where(item => item.Equals(Grade.S))).Count();
                song.Score = (int[])current.score.Clone();
            }
            else
            {
                save.Songs.Add(new SaveData.SongSave(song.Path));
            }
        }
        sr.Close();
        sr.Dispose();
        NoteController.isAutoPlay = save.SystemSettings.isAutoPlay;
        NoteController.speed = save.SystemSettings.speed;
        NoteController.hitVolume = (float)save.SystemSettings.hitVol;
        MainSceneManager.secret = save.SystemSettings.secret;
        MainSceneManager.ending = sCount >= 2;
        save.SystemSettings = new SaveData.Settings
        {
            isAutoPlay = save.SystemSettings.isAutoPlay,
            speed = save.SystemSettings.speed,
            hitVol = save.SystemSettings.hitVol,
            ending = MainSceneManager.ending,
            secret = save.SystemSettings.secret,
            endingSeen = save.SystemSettings.endingSeen
        };
        SavePrefs();
        SongManager.songList.Find(item => item.Path.Equals("wwb")).Unlock = save.SystemSettings.secret;
    }
    public static void InitializeSave(string filePath)
    {
        save = new SaveData();
        foreach (var song in SongManager.songList)
        {
            save.Songs.Add(new SaveData.SongSave(song.Path));
        }
        var jsonStr = JsonMapper.ToJson(save);
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(jsonStr);
        sw.Close();
        sw.Dispose();
    }
    public static void GetList()
    {
        SongManager.songList.Clear();
        TextAsset text = Resources.Load<TextAsset>("SongList");
        var lines = text.text.Split('\n');
        foreach (var item in lines)
        {
            var tmp = item.Split(',');
            var name = tmp[0].Trim('\"');
            var artist = tmp[1].Trim('\"');
            var path = tmp[2];
            var ez = int.Parse(tmp[3]);
            var nm = int.Parse(tmp[4]);
            var hd = int.Parse(tmp[5]);
            var song = new Song(name, artist, path, ez, nm, hd);
            SongManager.songList.Add(song);
        }
    }
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
    public static void GetPrefs()
    {
        if (!File.Exists(filePath))
        {
            InitializeSave(filePath);
        }
        else
        {
            GetSave();
        }
    }
    public static float GetAlpha(int startTime, int endTime)
    {
        float alpha;
        float start = startTime / 1000.0f;
        float end = endTime / 1000.0f;
        float time = Time.timeSinceLevelLoad - NoteController.NoteSpeed;
        if (time > end - 0.3f)
        {
            alpha = Mathf.Lerp(1.0f, 0.0f, Mathf.InverseLerp(end - 0.3f, end, time));
            Debug.Log(alpha);
        }
        else
        {
            alpha = Mathf.Lerp(0.0f, 1.0f, Mathf.InverseLerp(start, start + 0.3f, time));
        }

        return alpha;
    }

}