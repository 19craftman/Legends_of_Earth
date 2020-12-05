using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelect : MonoBehaviour
{
    AudioSource GameMusic;
    public AudioClip CurrentSong;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetString("SelectedSong") == null || PlayerPrefs.GetString("SelectedSong") == "")
        {
            PlayerPrefs.SetString("SelectedSong", "SillyFeet");
            PlayerPrefs.SetFloat("SelectedSongNumber", 1);
        }
        GameMusic = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
        var CurrentSong = Resources.Load<AudioClip>("AudioR/" + PlayerPrefs.GetString("SelectedSong"));
        GameMusic.clip = CurrentSong;
        GameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameMusic.clip.name);
        //Debug.Log("1" + PlayerPrefs.GetString("SelectedSong") + "1");
    }

    public void SetSong(float SongNumber)
    {
        if (SongNumber == 1)
        {
            //Debug.Log("song1");
            PlayerPrefs.SetString("SelectedSong", "SillyFeet");
        }
        if (SongNumber == 2)
        {
            PlayerPrefs.SetString("SelectedSong", "Boomerang");
        }

        if (SongNumber == 3)
        {
            PlayerPrefs.SetString("SelectedSong", "SteamtechMayhem");
        }

        if (SongNumber == 4)
        {
            PlayerPrefs.SetString("SelectedSong", "Stardust");
        }

        PlayerPrefs.SetFloat("SelectedSongNumber", SongNumber);
        var CurrentSong = Resources.Load<AudioClip>("AudioR/" + PlayerPrefs.GetString("SelectedSong"));
        GameMusic.clip = CurrentSong;
        
        if (!GameMusic.isPlaying)
        {
            GameMusic.Play();
        }
        
    }
}
