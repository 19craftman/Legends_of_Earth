using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 4;
    private string horizontal;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = GetComponent<PlayerInput>().horizontal;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis(horizontal);
        float xSpeed = rb.velocity.x;
        if (horizontalInput != 0)
        {
            xSpeed += horizontalInput * speed;
            xSpeed = Mathf.Clamp(xSpeed, -speed, speed);
        }
        else if (xSpeed != 0)
            xSpeed = 0;

        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

        if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
