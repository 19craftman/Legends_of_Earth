using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    float speed = 6;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("J2Horizontal") * speed * rb.gravityScale, rb.velocity.y);
    }
  
}
