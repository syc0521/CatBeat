using System.Collections.Generic;
using System.Linq;
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
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Utils.GetPrefs();
        InitializeList();
        PlayAudio(CurrentSong);
        if (currentDiff.Equals(Diff.Easy))
        {
            currentDiff = Diff.Easy;
        }
        ezBtn.color = new Color(0.75f, 0.65f, 1.0f);
    }
    private void Update()
    {
        UpdateText();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadingManager.nextScene = "Main";
            SceneManager.LoadScene("Loading");
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Utils.InitializeSave(Utils.filePath);
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
    private void InitializeList()
    {
        List<Selectable> buttonList = new List<Selectable>();
        foreach (var song in songList.Where(song => song.Unlock))//生成按钮
        {
            var obj = Instantiate(songBtn).GetComponent<SongButton>();
            obj.transform.SetParent(songPanel, false);
            obj.song = song;
            buttonList.Add(obj.gameObject.GetComponent<Button>());
        }
        for (int i = 0; i < buttonList.Count; i++)//设置导航
        {
            Navigation navigation = buttonList[i].navigation;
            navigation.mode = Navigation.Mode.Explicit;
            if (i == 0)
            {
                navigation.selectOnDown = buttonList[1];
            }
            else if (i == buttonList.Count - 1)
            {
                navigation.selectOnUp = buttonList[buttonList.Count - 2];
            }
            else
            {
                navigation.selectOnUp = buttonList[i - 1];
                navigation.selectOnDown = buttonList[i + 1];
            }
            buttonList[i].navigation = navigation;
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
