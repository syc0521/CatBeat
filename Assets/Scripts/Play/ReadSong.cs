﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Diff { Easy = 0, Normal = 1, Hard = 2 }
public class ReadSong : MonoBehaviour
{
    [HideInInspector]
    public int bpm;
    public string path;
    public NoteController controller;
    public Diff diff;

    void Start()
    {
        GetMap();
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
            NoteData note = new NoteData(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]));
            controller.notes.Add(note);
        }

    }
}
