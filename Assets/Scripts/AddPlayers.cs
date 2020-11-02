using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayers : MonoBehaviour
{
    public int playerCount;
    public static List<GameObject> players = new List<GameObject>();
    public GameObject[] prefabs;
    public List<int> chosen = new List<int>();
    

    

    // Start is called before the first frame update
    void Awake()
    {
        players.Clear();
        playerCount = 0;
        addPlayer();
        addPlayer();
        Debug.Log(players.Count);
        ////Time.timeScale = 0;
        GetComponent<SpawnPlayer>().Spawn();
        GetComponent<ApplyModifier>().Apply(PlayerPrefs.GetInt("ModInt"));
    }

    // Update is called once per frame
    void Update()
    {
      //  if(Input.GetAxisRaw("Start")==1)
      //  {

            //Time.timeScale = 1;
       // }
        
    }

    public void addPlayer()
    {
        if(playerCount<4)
        {
            players.Add(PlayerSelect());
            playerCount++;
            //players.Add(prefabs[PlayerSelect()]);
        }
    }

    public GameObject PlayerSelect()
    {
        int index = UnityEngine.Random.Range(0, prefabs.Length);
        if(prefabs[index] != null)
        {
            GameObject temp = prefabs[index];
            prefabs[index] = null;
            return temp;
        }
        else
        {
            return PlayerSelect();
        }
    }
}
