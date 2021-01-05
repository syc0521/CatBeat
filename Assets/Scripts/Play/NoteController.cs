//#define testMode
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum JudgeType 
{ 
    Perfect = 0, EarlyGreat = 1, LateGreat = 2, EarlyGood = 3, LateGood = 4, Miss = -1, Default = -2
};
public enum Diff { Easy = 0, Normal = 1, Hard = 2 }

public class NoteController : MonoBehaviour
{
    public GameObject tap_R, tap_B, tap_P;
    public GameObject hold_R, hold_B;
    public GameObject quickTap, micInput;
    public Transform startPos, endPos;
    public Transform judgePos;
    public static List<NoteData> notes = new List<NoteData>();
    public static List<Note> noteObjs = new List<Note>();
    public static float NoteSpeed => 3 - 0.3f * speed;
    public static int combo;
    public TextMeshPro comboText;
    public TextMeshPro scoreText;
    public static int score;
    public static readonly float perfectTime = 0.055f;
    public static readonly float greatTime = 0.09f;
    public static readonly float goodTime = 0.15f;
    public static int perfect, great, good, miss;
    public static float hitVolume;
    public static int noteCount;
    public static bool isAutoPlay;
    public static int speed;
    public static bool isPaused = false;
    public GameObject pauseCanvas;
    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public int bpm;
    public static int maxCombo;
    public static bool isTutorial;
#if testMode
    public string path;
    public Diff diff;
#else
    public static string path;
    public static Diff diff;
#endif

    public static float Multiplier => 1.00f + combo / 50 * 0.05f;
    private void Awake()
    {
        isPaused = false;
        notes.Clear();
        noteObjs.Clear();
        //isAutoPlay = IsAutoPlay;
        score = 0; combo = 0;
        perfect = 0; great = 0; good = 0; miss = 0;
        GetMap();
        source = GetComponent<AudioSource>();
        StartCoroutine(GetSong());
    }
    void Start()
    {
        foreach (NoteData note in notes)
        {
            StartCoroutine(CreateNote(note));
        }
    }
    private void Update()
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
        comboText.text = Utils.ConvertDigit(combo);
        scoreText.text = score.ToString();
        PauseGame();
    }

    private void GetMap()
    {
        TextAsset text = Resources.Load<TextAsset>("Songs/" + path + "/" + (int)diff);
        var lines = text.text.Split('\n');
        bpm = int.Parse(lines[0].Substring(5));
        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i].Split(',');
            NoteData note = new NoteData(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]))
            {
                Index = i - 1,
                CanJudge = false
            };
            notes.Add(note);
        }
        notes.Sort();
        noteCount = notes.Count;
        notes[0].CanJudge = true;
    }
    private IEnumerator GetSong()
    {
        var clip = Resources.Load<AudioClip>("Songs/" + path + "/song");
        source.clip = clip;
        source.playOnAwake = false;
        yield return new WaitForSeconds(NoteSpeed);
        source.Play();
        yield return new WaitForSeconds(clip.length);
        if (isAutoPlay || path.Equals("tut"))
        {
            LoadingManager.nextScene = "Select";
            SceneManager.LoadScene("Loading");
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }

    private void PauseGame()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                source.Pause();
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private IEnumerator CreateNote(NoteData note)
    {
        yield return new WaitForSeconds(note.Time);
        Note noteObj = null;
        switch (note.Type)
        {
            case NoteType.Tap:
                noteObj = CreateTap(note);
                break;
            case NoteType.Hold:
                noteObj = CreateHold(note);
                break;
            case NoteType.QuickTap:
                noteObj = CreateQuickTap(note);
                break;
            case NoteType.MicInput:
                noteObj = CreateMicInput(note);
                break;
        };
        noteObj.Data = note;
        noteObj.startPos = startPos.position;
        noteObj.endPos = endPos.position;
        noteObj.judgePos = judgePos.position;
        noteObjs.Add(noteObj);
    }
    private Note CreateTap(NoteData note)
    {
        Tap tap;
        if (note.Information == 1)
        {
            tap = Instantiate(tap_R, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        else if (note.Information == 2)
        {
            tap = Instantiate(tap_B, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        else
        {
            tap = Instantiate(tap_P, startPos.position, Quaternion.identity).GetComponent<Tap>();
        }
        return tap;
    }
    private Note CreateHold(NoteData note)
    {
        Hold hold = null;
        if (note.Information == 1)
        {
            hold = Instantiate(hold_R, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        else if (note.Information == 2)
        {
            hold = Instantiate(hold_B, startPos.position, Quaternion.identity).GetComponent<Hold>();
        }
        return hold;
    }
    private Note CreateQuickTap(NoteData note)
    {
        QuickTap qtap = Instantiate(quickTap, startPos.position, Quaternion.identity).GetComponent<QuickTap>();
        return qtap;
    }
    private Note CreateMicInput(NoteData note)
    {
        MicInput mic = Instantiate(micInput, startPos.position, Quaternion.identity).GetComponent<MicInput>();
        return mic;
    }
}
