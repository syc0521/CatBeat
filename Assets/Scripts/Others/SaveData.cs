﻿using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public enum Grade { S, A, B, C, D }

[Serializable]
public class SaveData
{
    [Serializable]
    public struct SongSave
    {
        public string path;
        public int[] score;
        public Grade[] grade;

        public SongSave(string path)
        {
            this.path = path;
            score = new int[3];
            grade = new Grade[3] { Grade.D, Grade.D, Grade.D };
        }
    }
    [Serializable]
    public struct Settings
    {
        public bool isAutoPlay;
        public int speed;
        public float hitVol;
    }
    private List<SongSave> songs;
    private Settings systemSettings;

    public Settings SystemSettings { get => systemSettings; set => systemSettings = value; }
    public List<SongSave> Songs { get => songs; set => songs = value; }
    public SaveData()
    {
        songs = new List<SongSave>();
        systemSettings = new Settings
        {
            isAutoPlay = false,
            speed = 4,
            hitVol = 0.8f
        };
    }
}
