using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is where we will put the death animations for later
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject a = Instantiate(collision.gameObject.GetComponent<PlayerInput>().dead);
            a.transform.position = collision.gameObject.transform.position;
            collision.gameObject.SetActive(false);
        }
    }
}
