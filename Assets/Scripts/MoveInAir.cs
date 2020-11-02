using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MoveInAir : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 6;
   // public LayerMask Ground;
    private string horizontal;

    int verticleRays = 5;
    float marginX = .05f;
    float marginY = .05f;
    Rect box;

    bool grounded = false;
    [SerializeField] private Player player;
    private int PlayerIDNew;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        player = ReInput.players.GetPlayer(PlayerIDNew);
        // horizontal = GetComponent<PlayerInput>().horizontal;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        box = new Rect(
            GetComponent<BoxCollider2D>().bounds.min.x,
            GetComponent<BoxCollider2D>().bounds.min.y,
            GetComponent<BoxCollider2D>().bounds.size.x,
            GetComponent<BoxCollider2D>().bounds.size.y
            );

        if (grounded != true)
        {
            float horizontalInput = player.GetAxis("horizontal");
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        grounded = isGrounded();
    }

    bool isGrounded()
    {
        Vector2 startPoint = new Vector2(box.xMin + marginX, box.center.y);
        Vector2 endPoint = new Vector2(box.xMax - marginX, box.center.y);

        RaycastHit2D hitInfo;

        float distance = box.height / 2 + (grounded ? marginY : Mathf.Max(Mathf.Abs(rb.velocity.y * Time.deltaTime), marginY));


        for (int i = 0; i < verticleRays; i++)
        {
            float lerpAmount = (float)i / (float)(verticleRays - 1);
            Vector3 origin = Vector2.Lerp(startPoint, endPoint, lerpAmount);
            //Debug.Log(distance);

            hitInfo = Physics2D.Raycast(origin, Vector2.down, distance, 256);

            if (hitInfo.collider != null)
            {
                return true;
            }
        }

        return false;
    }
}
