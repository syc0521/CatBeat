using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadList : MonoBehaviour
{
    public static List<Song> songList = new List<Song>();
    public Text[] diffBtn = new Text[3];
    public Text songName, songArtist;
    public GameObject songBtn;
    public Transform songPanel;
    public Song currentSong = null;
    private void Awake()
    {
        GetList();
    }
    private void Update()
    {
        diffBtn[0].text = currentSong.EasyLevel.ToString();
        diffBtn[1].text = currentSong.NormalLevel.ToString();
        diffBtn[2].text = currentSong.HardLevel.ToString();
        songName.text = currentSong.Name;
        songArtist.text = currentSong.Artist;
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
}
