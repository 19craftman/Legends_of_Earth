using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HotPotato : MonoBehaviour
{
    private GameObject[] players;
    private int count;
    private int winner;
    private int potatoperson;
    private int deadpotatoperson;
    private static float potatotime;
    private int starttime = 30;
    private float potatocooldown = 0;
    public TextMeshProUGUI potatoTimer;

    public AudioSource PotatoSwapped;
    public AudioSource PotatoBoom;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        hotPotato();
    }

    // Update is called once per frame
    void Update()
    {
     
     
        gameObject.transform.position = new Vector2(players[potatoperson].transform.position.x, players[potatoperson].transform.position.y+1f);
        count = 0;
        if (potatocooldown > 0)
        {
           potatocooldown -= Time.deltaTime;
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (players[potatoperson].GetComponent<BoxCollider2D>().IsTouching(players[i].GetComponent<BoxCollider2D>()) && potatocooldown <= 0)
            {
                potatoperson = i;
                PotatoSwapped.Play();
                potatocooldown = 1;
            }
                if (players[i].activeInHierarchy == true)
            {
                winner = i;
                count++;
            }
        }
        if (count == 1)
        {
            //winScreen.SetActive(true);

            //MainText.text = players[winner].GetComponent<PlayerInput>().character + " you won!";
            // state.text = "You Win!";
            //Time.timeScale = 0;
            gameObject.SetActive(false);
            Debug.Log("Winner");

        }
        if (potatotime > 0)
        {
            if (PlayerPrefs.GetFloat("start") == 1)
            {
                potatotime -= Time.deltaTime;
            }
        }
        else
        {
            potatoDeath();
        }
        potatoTimer.text = Mathf.Round(potatotime) + "s";
    }
    public void hotPotato()
    {
        potatotime = starttime;
        if (players.Length > 1)
        {

            potatoperson = Random.Range(0, players.Length);

        }

        else
        { }

    }
    public void potatoDeath()
    {
        deadpotatoperson = potatoperson;
        PotatoBoom.Play();
        hotPotato();
        players[deadpotatoperson].SetActive(false);

    }
    
}
