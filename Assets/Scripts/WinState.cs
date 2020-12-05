using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;

public class WinState : MonoBehaviour
{
    //private List<GameObject> players = new List<GameObject>();
    private GameObject[] players;

    public GameObject winScreen;
    public GameObject drawScreen;
    public TextMeshProUGUI MainText;
    public TextMeshProUGUI state;
    public Button restartgame;
    private bool once;
    private int count;
    private int winner;
    // Start is called before the first frame update
    void Start()
    {
        once = true;
        players = GameObject.FindGameObjectsWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].activeInHierarchy == true)
            {
                winner = i;
                count++;
            }
        }
        if (count == 1)
        {
            winScreen.SetActive(true);
           // restartgame.enabled = true;
            MainText.text = players[winner].GetComponent<PlayerInput>().character +" you won!";
            if (once)
            {
                PlayerPrefs.SetInt(players[winner].GetComponent<PlayerInput>().characterpoints, PlayerPrefs.GetInt(players[winner].GetComponent<PlayerInput>().characterpoints) + 1);
                Debug.Log(players[winner].GetComponent<PlayerInput>().character + " has " + PlayerPrefs.GetInt(players[winner].GetComponent<PlayerInput>().characterpoints) + "Points");
                once = false;
            }
            state.text = "You Win!";
            Time.timeScale = 0;
           
        }
        else if(count<1)
        {
            winScreen.SetActive(true);
            state.text = "Game Over";
            MainText.text =  "It's a Draw!";
            
           // restartgame.enabled = true;
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}








