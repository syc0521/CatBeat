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
        Score = new int[3] { 0, 0, 0 };
        GradeLevel = new Grade[3] { Grade.D, Grade.D, Grade.D };
    }

    public string Name { get; set; }
    public string Artist { get; set; }
    public string Path { get; set; }
    public int EasyLevel { get; set; }
    public int NormalLevel { get; set; }
    public int HardLevel { get; set; }
    public int[] Score { get; set; }
    public Grade[] GradeLevel { get; set; }
    public bool Unlock { get; set; }
    
}
