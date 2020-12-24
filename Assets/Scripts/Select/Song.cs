using System;
using System.Collections.Generic;

public class Song
{
    public Song(string name, string artist, string path, int easyLevel, int normalLevel, int hardLevel)
    {
        Name = name;
        Artist = artist;
        Path = path;
        EasyLevel = easyLevel;
        NormalLevel = normalLevel;
        HardLevel = hardLevel;
        Unlock = true;
    }

    public string Name { get; set; }
    public string Artist { get; set; }
    public string Path { get; set; }
    public int EasyLevel { get; set; }
    public int NormalLevel { get; set; }
    public int HardLevel { get; set; }
    public bool Unlock { get; set; }
    
}
