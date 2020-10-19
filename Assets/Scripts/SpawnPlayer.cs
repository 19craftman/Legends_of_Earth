using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
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

    public void Spawn()
    {
        Debug.Log(1);
        for(int i=0; i<GameStart.players.Count; i++)
        {
            Debug.Log(2);
            GameObject a = Instantiate(GameStart.players[i]);
            a.transform.position = positions[i];
        }
    }
}
