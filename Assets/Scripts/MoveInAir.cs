using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInAir : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
   // public LayerMask Ground;
    private string horizontal;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = GetComponent<PlayerInput>().horizontal;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded() != true)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed, rb.velocity.y);
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, gameObject.transform.localScale.y + .1f, 256);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
