using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animating : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    Rect box;

    int verticleRays = 5;
    float margin = .05f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        box = new Rect(
            GetComponent<BoxCollider2D>().bounds.min.x,
            GetComponent<BoxCollider2D>().bounds.min.y,
            GetComponent<BoxCollider2D>().bounds.size.x,
            GetComponent<BoxCollider2D>().bounds.size.y
            );
        if(rb.velocity != Vector2.zero)
        {
            if (anim.GetBool("Idle"))
            {
                anim.SetBool("Idle", false);
            }


            if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            else if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }

            if (!isGrounded())
            {
                anim.SetBool("Jump", true);
            }
            else if (anim.GetBool("Jump"))
            {
                anim.SetBool("Jump", false);
            }
        }
        else if(!anim.GetBool("Idle"))
        {
            anim.SetBool("Idle", true);
        }
        

       
        
    }

    bool isGrounded()
    {
        Vector2 startPoint = new Vector2(box.xMin + margin, box.center.y);
        Vector2 endPoint = new Vector2(box.xMax - margin, box.center.y);

        RaycastHit2D hitInfo;

        float distance = box.height / 2 + margin; 


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
