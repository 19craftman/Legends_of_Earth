using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    public float totalTime;
    public float timeRemaining;

    List<Vector2> positions;
    GameObject[] players;
   
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        players = GameObject.FindGameObjectsWithTag("Player");
        CountDown.Count += countDown;
        timeRemaining = totalTime;
    }

    void playersLeftAlive()
    {
        positions.Clear();
        foreach(GameObject player in players)
        {
            if(player.activeInHierarchy)
            {
                positions.Add(player.transform.position);
            }
        }
    }

    Vector2 randomPosition()
    {
        int index = Random.Range(0, positions.Count);
        Vector2 temp = positions[index];
        positions.Remove(temp);
        return temp;
    }

    void shufflePlayers()
    {
        foreach(GameObject player in players)
        {
            if(player.activeInHierarchy)
            {
                player.transform.position = randomPosition();
            }
        }
    }

    void countDown(float time)
    {
        timeRemaining -= time;
        if(timeRemaining<=0.0)
        {
            playersLeftAlive();
            shufflePlayers();
            timeRemaining = totalTime;
        }
    }
}
