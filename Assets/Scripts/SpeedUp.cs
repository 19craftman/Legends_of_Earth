using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class SpeedUp : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 8;
    private string horizontal;
    [SerializeField] private Player player;
    private int PlayerIDNew;
    // Start is called before the first frame update
    void Start()
    {
        PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        player = ReInput.players.GetPlayer(PlayerIDNew);
        //horizontal = GetComponent<PlayerInput>().horizontal;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = player.GetAxis("horizontal");
        float xSpeed = rb.velocity.x;
        //Debug.Log(horizontalInput);
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
