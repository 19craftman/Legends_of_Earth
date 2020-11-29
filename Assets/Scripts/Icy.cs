using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Icy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 4;
    private string horizontal;
    [SerializeField] private Player player;
    private int PlayerIDNew;

    Rect box;

    int verticleRays = 5;
    float marginX = .05f;
    float marginY = .05f;


    void Start()
    {
        PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        player = ReInput.players.GetPlayer(PlayerIDNew);
        //horizontal = GetComponent<PlayerInput>().horizontal;
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

        float horizontalInput = player.GetAxis("horizontal");
        float xSpeed = rb.velocity.x;
        Debug.Log(horizontalInput);
        if (horizontalInput != 0)
        {
            xSpeed += horizontalInput * speed;
            xSpeed = Mathf.Clamp(xSpeed, -speed, speed);
        }
        else if (xSpeed != 0)
        {
            if(isGrounded())
            {
                if (xSpeed < 0)
                    xSpeed = Mathf.Min(xSpeed + (speed * .01f), 0);
                else
                    xSpeed = Mathf.Max(xSpeed - (speed * .01f), 0);
            }
            else
            {
                if (xSpeed < 0)
                    xSpeed = Mathf.Min(xSpeed + (speed * .05f), 0);
                else
                    xSpeed = Mathf.Max(xSpeed - (speed * .05f), 0);
            }
        }
            

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

    bool isGrounded()
    {
        Vector2 startPoint = new Vector2(box.xMin + marginX, box.center.y);
        Vector2 endPoint = new Vector2(box.xMax - marginX, box.center.y);

        RaycastHit2D hitInfo;

        float distance = box.height / 2 + marginY;


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