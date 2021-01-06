using System;
using System.Collections.Generic;

[Serializable]
public enum Grade { S, A, B, C, D }

[Serializable]
public class SaveData
{
    [Serializable]
    public class SongSave
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
        public SongSave()
        {

        }
        public override string ToString()
        {
            return path + grade[0] + grade[1];
        }
    }
    [Serializable]
    public struct Settings
    {
        public bool isAutoPlay;
        public int speed;
        public double hitVol;
        public bool secret;
        public bool ending;
        public bool tutFinished;
        public bool endingSeen;
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
            speed = 8,
            hitVol = 0.8,
            secret = false,
            ending = false,
            endingSeen = false,
            tutFinished = false
        };
    }
}
