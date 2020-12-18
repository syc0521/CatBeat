﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData
{
    public NoteData(int type, int time, int dur, int information)
    {
        Type = type;
        Time = time / 1000.0f;
        Dur = dur / 1000.0f;
        Information = information;
        CanJudge = false;
    }
    /// <summary>
    /// 1tap 2hold 3连打 4摇杆 5语音
    /// </summary>
    public int Type { set; get; }
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
}
