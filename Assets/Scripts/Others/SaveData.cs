using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    [Serializable]
    public struct SongSave
    {
        public string path;
        public int[] score = new int[3];
        public SongSave(string path)
        {
            this.path = path;
            score = 0;
        }
    }
    [Serializable]
    public struct Settings
    {
        public bool isAutoPlay;
        public int speed;
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
            speed = 4
        };
    }
}
