using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCamera : MonoBehaviour
{

    void OnBecameInvisible()
    {
        //Debug.Log("helloThere");
        
           // GameObject a = Instantiate(gameObject.GetComponent<PlayerInput>().dead);
            //a.transform.position = gameObject.transform.position;
        
        gameObject.SetActive(false);
    }
}
