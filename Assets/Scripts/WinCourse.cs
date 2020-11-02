using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCourse : MonoBehaviour
{
    private GameObject[] players;
    private int winner;
    public GameObject winScreen;
    public TextMeshProUGUI winnerName;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is where we will put the death animations for later
        if (collision.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            winnerName.text = players[winner].GetComponent<PlayerInput>().character + " you won!";
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
