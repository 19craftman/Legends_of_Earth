/* code heavily utilizes tutorial found here: http://deranged-hermit.blogspot.com/2014/01/2d-platformer-collision-detection-with.html
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJump : MonoBehaviour
{
    float gravity = .25f;
    float maxFall = -30f;
    public float maxJump =-1f;
    float jumpForce = .5f;

    Rect box;

    public Vector2 velocity;

    public bool grounded = false;
    bool falling = false;

    int verticleRays = 5;
    float marginX = .05f;
    float marginY = .05f;

    private Rigidbody2D rb;
   // public LayerMask Ground;
    private string jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<PlayerInput>().jump;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(jump);
    }


    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        box = new Rect(
            GetComponent<BoxCollider2D>().bounds.min.x,
            GetComponent<BoxCollider2D>().bounds.min.y,
            GetComponent<BoxCollider2D>().bounds.size.x,
            GetComponent<BoxCollider2D>().bounds.size.y
            );
        if(!grounded && maxJump <=0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y - gravity, maxFall));
        }

        if (rb.velocity.y < 0)
            falling = true;
        //Debug.DrawRay(new Vector2(box.xMin + marginX, box.center.y), new Vector2(0, -(box.height / 2 + (grounded ? marginY : Mathf.Abs(velocity.y * Time.deltaTime)))), Color.cyan);

        if (grounded || falling)
        {
            grounded = isGrounded();
            if (grounded)
            {
                falling = false;
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                if (Input.GetAxisRaw(jump) == 0)
                {
                    maxJump = 10;
                }
            }

        }

        if ( Input.GetAxisRaw(jump) == 1)
        {
            rb.AddForce(Vector2.up * Mathf.Max(maxJump, 0f));

            if (maxJump > 0)
                maxJump -= jumpForce;
        }

    }

    bool isGrounded()
    {
        Vector2 startPoint = new Vector2(box.xMin + marginX, box.center.y);
        Vector2 endPoint = new Vector2(box.xMax - marginX, box.center.y);

        RaycastHit2D hitInfo;

        float distance = box.height / 2 + (grounded ? marginY : Mathf.Max(Mathf.Abs(rb.velocity.y * Time.deltaTime), marginY));

        bool connected = false;

        for (int i = 0; i < verticleRays; i++)
        {
            float lerpAmount = (float)i / (float)(verticleRays - 1);
            Vector3 origin = Vector2.Lerp(startPoint, endPoint, lerpAmount);
            //Debug.Log(distance);

            hitInfo = Physics2D.Raycast(origin, Vector2.down, distance, 256);

            if (hitInfo.collider != null)
            {
                connected = true;
                break;
            }
        }

        return connected;
    }
}
