/*
 * follow script is modified version of a script found at https://answers.unity.com/questions/1153326/does-anyone-know-the-script-for-a-smooth-camera-fo.html
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;

public class FollowLead : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    private GameObject[] players;
    private int index;
    private int count;
    private int first;
    public GameObject winScreen;
    public TextMeshProUGUI MainText;
    public TextMeshProUGUI state;
    public Button restartgame;
    public bool once;
    private void Start()
    {
        once = true;
        target_Offset = new Vector3(transform.position.x - target.position.x, transform.position.y, transform.position.z);
        players = GameObject.FindGameObjectsWithTag("Player");
        index = 0;
        first = 0;
    }

    void Update()
    {
        count = 0;
        for(int i=0; i<players.Length; i++)
        {
            if(players[i].activeInHierarchy)
            {
                if(players[i].transform.position.x > players[index].transform.position.x)
                {
                    index = i;
                }
            }
            if (players[i].activeInHierarchy == false)
            {
                count++;
            }
           
        }
        for (int t = 0; t < players.Length; t++)
        {
            if (players[t].transform.position.x > players[first].transform.position.x)
            {
                first = t;
            }
        }
        if (count == players.Length)
        {
            winScreen.SetActive(true);
            // restartgame.enabled = true;
            Debug.Log(first + players[first].GetComponent<PlayerInput>().character);
            MainText.text = players[first].GetComponent<PlayerInput>().character + " you won!";
            if (once)
            {
                PlayerPrefs.SetInt(players[first].GetComponent<PlayerInput>().characterpoints, PlayerPrefs.GetInt(players[first].GetComponent<PlayerInput>().characterpoints) + 1);
                Debug.Log(players[first].GetComponent<PlayerInput>().character + " has " + PlayerPrefs.GetInt(players[first].GetComponent<PlayerInput>().characterpoints) + "Points");
                once = false;
            }
            state.text = "You Win!";
            Time.timeScale = 0;


        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(players[index].transform.position.x, 0) + target_Offset, 0.1f);
  
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
