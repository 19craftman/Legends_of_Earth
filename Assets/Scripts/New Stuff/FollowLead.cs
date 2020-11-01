/*
 * follow script is modified version of a script found at https://answers.unity.com/questions/1153326/does-anyone-know-the-script-for-a-smooth-camera-fo.html
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLead : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    private GameObject[] players;
    private int index;
  
    private void Start()
    {
        target_Offset = new Vector3(transform.position.x - target.position.x, transform.position.y, transform.position.z);
        players = GameObject.FindGameObjectsWithTag("Player");
        index = 0;
    }

    void Update()
    {
        for(int i=0; i<players.Length; i++)
        {
            if(players[i].activeInHierarchy)
            {
                if(players[i].transform.position.x > players[index].transform.position.x)
                {
                    index = i;
                }
            }
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(players[index].transform.position.x, 0) + target_Offset, 0.1f);
   
    }
}
