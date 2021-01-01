﻿using LitJson;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static SaveData save;
    public static readonly string filePath = "D:\\save.json";
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
        foreach (var song in SongManager.songList)
        {
            var current = save.Songs.Find(item => item.path.Equals(song.Path));
            if (current != null)
            {
                song.GradeLevel = (Grade[])current.grade.Clone();
                song.Score = (int[])current.score.Clone();
            }
            else
            {
                save.Songs.Add(new SaveData.SongSave(song.Path));
            }
        }
        sr.Close();
        sr.Dispose();
        SavePrefs();
        NoteController.isAutoPlay = save.SystemSettings.isAutoPlay;
        NoteController.speed = save.SystemSettings.speed;
        NoteController.hitVolume = (float)save.SystemSettings.hitVol;
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
}

