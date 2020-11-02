using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class SpawnPlayer : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Debug.Log(1);
        for(int i=0; i<AddPlayers.players.Count; i++)
        {
            Debug.Log(2);
            
            GameObject a = Instantiate(AddPlayers.players[i]);
            a.GetComponent<PlayerInput>().PlayerID = i;
            GetComponent<RelocatePlayer>().Move();
        }
    }
}
