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
        InitializeList();
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
            Utils.InitializeSave(Utils.filePath);
        }
    }
    private void GetPrefs()
    {
        if (!File.Exists(Utils.filePath))
        {
            Utils.InitializeSave(Utils.filePath);
        }
        else
        {
            Utils.GetSave();
        }
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
    private void InitializeSongData()
    {
        foreach (var song in songList)
        {
            Utils.save.Songs.Add(new SaveData.SongSave(song.Path));
        }
        var jsonStr = JsonMapper.ToJson(Utils.save);
        StreamWriter sw = new StreamWriter(Utils.filePath);
        sw.Write(jsonStr);
        sw.Close();
        sw.Dispose();
    }
    private void InitializeList()
    {
        foreach (var song in songList)
        {
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
