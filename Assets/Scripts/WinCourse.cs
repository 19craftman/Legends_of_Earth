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
    public bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = true;
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
            winnerName.text = collision.gameObject.GetComponent<PlayerInput>().character + " you won!";
            if (once)
            {
                PlayerPrefs.SetInt(collision.gameObject.GetComponent<PlayerInput>().characterpoints, PlayerPrefs.GetInt(collision.gameObject.GetComponent<PlayerInput>().characterpoints) + 1);
                Debug.Log(collision.gameObject.GetComponent<PlayerInput>().character + " has " + PlayerPrefs.GetInt(collision.gameObject.GetComponent<PlayerInput>().characterpoints + " Points") + "Points");
                once = false;
            }
            Time.timeScale = 0;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
