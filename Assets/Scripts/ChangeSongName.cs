using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeSongName : MonoBehaviour
{

    public TextMeshProUGUI SongTitle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SongTitle = this.gameObject.GetComponent<TextMeshProUGUI>();
        SongTitle.GetComponentInParent<Slider>().value = PlayerPrefs.GetFloat("SelectedSongNumber");
    }

    // Update is called once per frame
    void Update()
    {
        SongTitle.text = "< " + PlayerPrefs.GetFloat("SelectedSongNumber") + ": " + PlayerPrefs.GetString("SelectedSong") + " >";
    }
}
