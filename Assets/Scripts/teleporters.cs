using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class teleporters : MonoBehaviour
{
    public GameObject[] teleport;
   
    public GameObject[] teleportspawn;
  
    private GameObject[] players;
    private float teleporttime = 0;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (teleporttime > 0)
        {
            teleporttime -= Time.deltaTime;
        }
        else
        {
        }
        for (int i = 0; i < players.Length; i++)
        {
            for (int t = 0; t < teleport.Length; t++)
            {
                if (players[i].GetComponent<BoxCollider2D>().IsTouching(teleport[t].GetComponent<TilemapCollider2D>()) && teleporttime <= 0)
                {
                    players[i].transform.position = teleportspawn[t].transform.position;
                    teleporttime = 1;
                }
            }
        }
    }

}