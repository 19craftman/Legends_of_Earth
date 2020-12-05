using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Placement : MonoBehaviour
{
    public Vector2[] placements;
    private GameObject[] players;
    public Transform thecanvas;
    public List<GameObject> scoring = new List<GameObject>();
   
    public List<Image> bars = new List<Image>();
    public int winscore;
    private float time = 15;
    public TextMeshProUGUI timing;
    public List<TextMeshProUGUI> score = new List<TextMeshProUGUI>();
    public Image timerbar;
    public GameObject nextButton;
    public GameObject backtomain;
    public TextMeshProUGUI maintext;
    private bool game;
    // Start is called before the first frame update
    void Start()
    {
        game = false;
        backtomain.SetActive(false);
        nextButton.SetActive(false);
        winscore = 3;
        scoring.Clear();
        bars.Clear();
        for (int i = 0; i < PlayerSelecting.playersScoring.Count; i++)
        {
        
            GameObject placementPieces = Instantiate(PlayerSelecting.playersScoring[i]);
            placementPieces.transform.SetParent(thecanvas);
            
            scoring.Add(placementPieces);
            bars.Add(scoring[i].GetComponentInChildren<Image>());
            Debug.Log(PlayerPrefs.GetInt(scoring[i].GetComponent<PlayerInput>().characterpoints));
            score.Add(scoring[i].GetComponentInChildren<TextMeshProUGUI>());
            score[i].text = PlayerPrefs.GetInt(scoring[i].GetComponent<PlayerInput>().characterpoints) + " Points";
            bars[i].fillAmount = (float)PlayerPrefs.GetInt(scoring[i].GetComponent<PlayerInput>().characterpoints) / (float)winscore;
            scoring[i].transform.position = placements[i];
            if (PlayerPrefs.GetInt(scoring[i].GetComponent<PlayerInput>().characterpoints) == 3)
            {
                maintext.text = scoring[i].GetComponent<PlayerInput>().character + " you won!!!";
                game = true;
            }

        }
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        timing.text = ""+Mathf.Round(time);
        if (time <= 0)
        {
            time = 0;
            if (game)
            {
                backtomain.SetActive(true);
            }
            else
            {
                nextButton.SetActive(true);
            }
        }
        else
        {
            time -= Time.deltaTime;
            
        }
        timerbar.fillAmount = time / 15;
    }
}
