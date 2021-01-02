using LitJson;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public static List<Song> songList = new List<Song>();
    public Text[] diffBtn = new Text[3];
    public TextMeshProUGUI songName, songArtist, scoreText;
    public GameObject songBtn;
    public Transform songPanel;
    public Toggle autoBtn;
    public Slider speedSli, volSli;
    private Diff currentDiff;
    public Sprite[] judgeSprite;
    public Song CurrentSong { get => currentSong; set => PlayAudio(value); }
    private Song currentSong;
    private AudioSource source;
    public Image ezBtn;
    public SpriteRenderer gradeSprite;
    private void Awake()
    {
        GetList();
        GetPrefs();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        CurrentSong = songList[0];
        currentDiff = Diff.Easy;
        ezBtn.color = new Color(0.75f, 0.65f, 1.0f);
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
            Utils.GetSave();
        }
    }
    private static void InitializeSave(string filePath)
    {
        Utils.save = new SaveData();
        foreach (var song in songList)
        {
            Utils.save.Songs.Add(new SaveData.SongSave(song.Path));
        }
        var jsonStr = JsonMapper.ToJson(Utils.save);
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
        currentDiff = NoteController.diff;
        diffBtn[0].text = CurrentSong.EasyLevel.ToString();
        diffBtn[1].text = CurrentSong.NormalLevel.ToString();
        diffBtn[2].text = CurrentSong.HardLevel.ToString();
        songName.text = CurrentSong.Name;
        songArtist.text = CurrentSong.Artist;
        scoreText.text = CurrentSong.Score[(int)currentDiff].ToString();
        gradeSprite.sprite = judgeSprite[(int)currentSong.GradeLevel[(int)currentDiff]];
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
