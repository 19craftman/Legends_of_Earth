using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    //public GameObject TurnOned;
    public GameObject[] bars;
    GameObject[] players;
    public string[] name;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for(int i =0; i <bars.Length; i++)
        {
            bool inGame = false;
            foreach(GameObject player in players)
            {
                //Debug.Log(name[i] + " compare " + player.GetComponent<PlayerInput>().character);
                if(name[i].Equals(player.GetComponent<PlayerInput>().character))
                {
                    inGame = true;
                    break;
                }
            }
            if(!inGame)
            {
                bars[i].SetActive(false);
            }
        }
        //TurnOned = GameObject.FindGameObjectWithTag("P3Death");
        
        //TurnOned.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
