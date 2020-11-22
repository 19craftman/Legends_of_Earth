using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSound : MonoBehaviour
{
    //creates for the a place to insert the ui sliders
    public Slider Master;
    public Slider Sound;
    public Slider Music;

    // Start is called before the first frame update
    void Start()
    {
        //sets the slider values equal to their corresponding playerpref float
        Master.value = PlayerPrefs.GetFloat("ppmaster") * .5f;
        Sound.value = PlayerPrefs.GetFloat("ppsound") * .5f;
        Music.value = PlayerPrefs.GetFloat("ppmusic") * .5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
