using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocatePlayer : MonoBehaviour
{
    public Vector2[] positions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0; i<players.Length; i++)
        {
            players[i].transform.position = positions[i];
        }
    }
}
