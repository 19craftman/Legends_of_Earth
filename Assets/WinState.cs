using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinState : MonoBehaviour
{
    //private List<GameObject> players = new List<GameObject>();
    private GameObject[] players;

    public GameObject winScreen;
    public GameObject drawScreen;
    public TextMeshProUGUI winnerName;

    private int count;
    private int winner;
    // Start is called before the first frame update
    void Start()
    {
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
            winnerName.text = players[winner].GetComponent<PlayerInput>().character +" you won!";
        }
        else if(count<1)
        {
            drawScreen.SetActive(true);
        }
    }
}








