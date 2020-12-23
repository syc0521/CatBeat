﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Diff { Easy = 0, Normal = 1, Hard = 2 }
public class ReadSong : MonoBehaviour
{
    [HideInInspector]
    public int bpm;
    private bool testMode = false;
#if testMode
    public string path;
    public Diff diff;
#else
    public static string path;
    public static Diff diff;
#endif
    public NoteController controller;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        GetMap();
        StartCoroutine(GetSong());
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
    /// <summary>
    /// 谱面读入
    /// </summary>
    private void GetMap()
    {
        TextAsset text = Resources.Load<TextAsset>("Songs/" + path + "/" + (int)diff);
        var lines = text.text.Split('\n');
        bpm = int.Parse(lines[0].Substring(5));
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i].Split(',');
            NoteData note = new NoteData(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]))
            {
                Index = i - 1, CanJudge = false
            };
            NoteController.notes.Add(note);
        }
        NoteController.noteCount = NoteController.notes.Count;
        NoteController.notes[0].CanJudge = true;
    }
    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetSong()
    {
        var clip = Resources.Load<AudioClip>("Songs/" + path + "/song");
        source.clip = clip;
        source.playOnAwake = false;
        yield return new WaitForSeconds(NoteController.noteSpeed);
        source.Play();
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("Result");
    }
}
