/* code heavily utilizes tutorial found here: http://deranged-hermit.blogspot.com/2014/01/2d-platformer-collision-detection-with.html
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class BaseJump : MonoBehaviour
{
    float gravity = .5f;
    float maxFall = -30f;
    public float maxJump =-1f;
    public float jumpForce = 2.35f;
    float jumpForceOrigin = 2.35f;
    float yLimit = 3f;

    Rect box;

    public Vector2 velocity;

    bool grounded = false;
    bool falling = false;

    int verticleRays = 5;
    float marginX = .05f;
    float marginY = .05f;

    public bool jumping;

    private Rigidbody2D rb;
   // public LayerMask Ground;
    private string jump;


    //testing
    public float testY;
    public int counterA;
    public int counterB;

    [SerializeField] private Player player;
    private int PlayerIDNew;
    void Start()
    {
        PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        player = ReInput.players.GetPlayer(PlayerIDNew);
        //jump = GetComponent<PlayerInput>().jump;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }


    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
       // testY=player.GetAxisRaw("Jump");
        velocity = rb.velocity;
        box = new Rect(
            GetComponent<BoxCollider2D>().bounds.min.x,
            GetComponent<BoxCollider2D>().bounds.min.y,
            GetComponent<BoxCollider2D>().bounds.size.x,
            GetComponent<BoxCollider2D>().bounds.size.y
            );


        if(!grounded)
        {
            
            if(belowGround())
            {
                counterA++;
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y - (gravity/2), maxFall));
            }
            else
            {
                counterB++;
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y - gravity, maxFall));
            }
        }

        if (rb.velocity.y < 0)
        {
            falling = true;
        }
            
        
        if (grounded || falling)
        {
            grounded = isGrounded();
            if (grounded)
            {
                falling = false;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                if (player.GetAxisRaw("Jump") == 0)
                {
                    jumping = false;
                    jumpForce = jumpForceOrigin;
                    maxJump = 5.85f;
                }
                    
            }

        }

        if (grounded && !jumping && player.GetAxisRaw("Jump") > 0)
        {
            
            counterA = 0;
            counterB = 0;
            jumping = true;
        }
//        else if(jumpForce==jumpForceOrigin && jumping)
//        {
 //           if(player.GetAxisRaw("Jump") == 0)
 //           {
//                jumpForce *= 2f;
//            }
                
//        }
        

        if(jumping && maxJump>0)
        {
            float yVelocity = rb.velocity.y + Mathf.Max(maxJump, 0f);
            if(belowGround())
            {
                yVelocity = Mathf.Min(yVelocity, yLimit);
                maxJump -= 1.5f * jumpForceOrigin;
            }
            else
            {
                maxJump -= jumpForce;
            }
            
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
        }
        

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

    bool belowGround()
    {
        Vector2 startPoint = new Vector2(box.xMin + marginX, box.center.y);
        Vector2 endPoint = new Vector2(box.xMax - marginX, box.center.y);

        RaycastHit2D hitInfo;

        float distance = box.height * 1.5f;

        //Debug.DrawLine(new Vector3(startPoint.x, startPoint.y, 0), new Vector3(startPoint.x, startPoint.y + distance, 0));


        for (int i = 0; i < verticleRays; i++)
        {
            float lerpAmount = (float)i / (float)(verticleRays - 1);
            Vector3 origin = Vector2.Lerp(startPoint, endPoint, lerpAmount);
            //Debug.Log(distance);

            hitInfo = Physics2D.Raycast(origin, Vector2.up, distance, 256);

            if (hitInfo.collider != null)
            {
                return true;
            }
        }

        return false;
    }
}
