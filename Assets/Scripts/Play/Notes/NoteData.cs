﻿using System;

public enum NoteType { Tap = 1, Hold = 2, QuickTap = 3, Slider = 4, MicInput = 5 }
public class NoteData : IComparable<NoteData>
{
    public NoteData(int type, int time, int dur, int information)
    {
        Type = (NoteType)type;
        Time = time / 1000.0f;
        Dur = dur / 1000.0f;
        Information = information;
    }
    /// <summary>
    /// 1tap 2hold 3连打 4摇杆 5语音
    /// </summary>
    public NoteType Type { set; get; }
    /// <summary>
    /// note出现的时间
    /// </summary>
    public float Time { get; set; }
    /// <summary>
    /// note持续时间
    /// </summary>
    public float Dur { set; get; }
    /// <summary>
    /// tap/hold:1红2蓝3紫
    /// 连打：连打次数
    /// </summary>
    public int Information { get; set; }
    /// <summary>
    /// 是否可判定
    /// </summary>
    public bool CanJudge { set; get; }
    public int Index { get; set; }

    public int CompareTo(NoteData other)
    {
        return (int)(Time * 1000.0f - other.Time * 1000.0f);
    }

    public override string ToString()
    {
        float dt = Time - UnityEngine.Time.timeSinceLevelLoad + NoteController.NoteSpeed;
        return "time=" + (Time * 1000f) + ", deltaTime=" + dt + ", judge=";
    }
}
