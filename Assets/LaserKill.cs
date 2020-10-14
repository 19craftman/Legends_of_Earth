using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Die");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Die");
            other.gameObject.SetActive(false);
        }

    }
   
  
}
