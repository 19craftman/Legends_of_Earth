using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Rigidbody2D rb;
    //public LayerMask Ground;
    public bool HasDouble = true;
    public bool HasJumped = false;
    private string jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = GetComponent<PlayerInput>().jump;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(jump);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(isGrounded());
        if (isGrounded())
        {
            HasDouble = true;
        }
        //Debug.DrawRay(transform.position, Vector2.down, Color.green, gameObject.transform.localScale.y + .1f);

       if(Input.GetAxisRaw(jump) == 0)
        {
            HasJumped = false;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw(jump) == 1 && !HasJumped)
        {
            if (isGrounded())
            {
                HasJumped = true;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, Input.GetAxisRaw(jump) * 360));
            }
            else if (HasDouble == true)
            {
                HasJumped = true;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, Input.GetAxisRaw(jump) * 360));
                HasDouble = false;
            }
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, gameObject.transform.localScale.y + .1f,256);
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
