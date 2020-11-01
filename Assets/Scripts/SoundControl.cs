using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundControl : MonoBehaviour
{
    //creates a place to put the audio mixer in
    public AudioMixer MasterVolume;
    //declares strings that will be used for playerpref names
    public string ppmaster;
    public string ppsound;
    public string ppmusic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //creates a function to set one of the audio mixer exposed parameters 
    public void SetMasterLevel(float MasterLevel)
    {
        //doubles the value so slider it is attached to later does not have as many values
        MasterLevel = MasterLevel * 2;
        //sets the MasterVolume audiomixer paramater equal to its corrasponding float 
        MasterVolume.SetFloat("MasterVol", MasterLevel);
        //sets a playerpref equal to the float
        PlayerPrefs.SetFloat("ppmaster", MasterLevel);
        ////Debug.Log(PlayerPrefs.GetFloat("pp1"));
    }

    //creates a function to set one of the audio mixer exposed parameters 
    public void SetMusicLevel(float MusicLevel)
    {
        //doubles the value so slider it is attached to later does not have as many values
        MusicLevel = MusicLevel * 2;
        //sets the MasterVolume audiomixer paramater equal to its corrasponding float 
        MasterVolume.SetFloat("MusicVol", MusicLevel);
        //sets a playerpref equal to the float
        PlayerPrefs.SetFloat("ppmusic", MusicLevel);
    }

    //creates a function to set one of the audio mixer exposed parameters 
    public void SetSoundLevel(float SoundLevel)
    {
        //doubles the value so slider it is attached to later does not have as many values
        SoundLevel = SoundLevel * 2;
        //sets the MasterVolume audiomixer paramater equal to its corrasponding float 
        MasterVolume.SetFloat("SoundVol", SoundLevel);
        //sets a playerpref equal to the float
        PlayerPrefs.SetFloat("ppsound", SoundLevel);
    }
}
