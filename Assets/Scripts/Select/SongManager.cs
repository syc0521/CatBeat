using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;

public class SongManager : MonoBehaviour
{
    public static List<Song> songList = new List<Song>();
    public Text[] diffBtn = new Text[3];
    public Text songName, songArtist, scoreText;
    public GameObject songBtn;
    public Transform songPanel;

    public Song CurrentSong { get => currentSong; set => PlayAudio(value); }
    private Song currentSong;
    private AudioSource source;
    private void Awake()
    {
        GetList();
        GetPrefs();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        CurrentSong = songList[0];
    }
    private void Update()
    {
        UpdateText();
        Utils.QuitProgram();
        if (Input.GetKeyDown(KeyCode.F12))
        {
            InitializeSave(Utils.filePath);
        }
    }
    private void GetPrefs()
    {
        if (!File.Exists(Utils.filePath))
        {
            InitializeSave(Utils.filePath);
        }
        else
        {
            GetSave(Utils.filePath);
        }
    }

    private void GetSave(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);
        SaveData save = JsonMapper.ToObject<SaveData>(sr.ReadToEnd());
        foreach (var song in save.Songs)
        {
            var current = songList.Find(item => item.Path.Equals(song.path));
            current.GradeLevel = (Grade[])song.grade.Clone();
            current.Score = (int[])song.score.Clone();
        }
        NoteController.isAutoPlay = save.SystemSettings.isAutoPlay;
        NoteController.speed = save.SystemSettings.speed;
        NoteController.hitVolume = save.SystemSettings.hitVol;
    }

    private static void InitializeSave(string filePath)
    {
        SaveData save = new SaveData();
        foreach (var song in songList)
        {
            save.Songs.Add(new SaveData.SongSave(song.Path));
        }
        var jsonStr = JsonMapper.ToJson(save);
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(jsonStr);
        sw.Close();
    }

    public void PlayAudio(Song song)
    {
        currentSong = song;
        AudioClip clip = Resources.Load<AudioClip>("Songs/" + song.Path + "/preview");
        source.clip = clip;
        source.Play();
    }
    private void UpdateText()
    {
        diffBtn[0].text = CurrentSong.EasyLevel.ToString();
        diffBtn[1].text = CurrentSong.NormalLevel.ToString();
        diffBtn[2].text = CurrentSong.HardLevel.ToString();
        songName.text = CurrentSong.Name;
        songArtist.text = CurrentSong.Artist;
        scoreText.text = CurrentSong.Score.ToString();
    }

    private void GetList()
    {
        TextAsset text = Resources.Load<TextAsset>("SongList");
        var lines = text.text.Split('\n');
        foreach (var item in lines)
        {
            var tmp = item.Split(',');
            var name = tmp[0].Trim('\"');
            var artist = tmp[1].Trim('\"');
            var path = tmp[2];
            var ez = int.Parse(tmp[3]);
            var nm = int.Parse(tmp[4]);
            var hd = int.Parse(tmp[5]);
            var song = new Song(name, artist, path, ez, nm, hd);
            songList.Add(song);
            var obj = Instantiate(songBtn).GetComponent<SongButton>();
            obj.transform.SetParent(songPanel, false);
            obj.song = song;
        }
        currentSong = songList[0];
    }
    public void JumpScene(Diff diff)
    {
        NoteController.diff = diff;
        NoteController.path = CurrentSong.Path;
        LoadingManager.nextScene = "Play";
        SceneManager.LoadScene("Loading");
    }
}
