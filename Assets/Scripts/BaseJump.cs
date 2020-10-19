using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJump : MonoBehaviour
{
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

    private void FixedUpdate()
    {
        Debug.Log(isGrounded());
        Debug.Log(Input.GetAxisRaw(jump));
        Debug.DrawRay(transform.position, Vector2.down, Color.green, gameObject.transform.localScale.y + .1f);
        if (isGrounded() && Input.GetAxisRaw(jump) == 1)
        {

            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 360));
        }
    }

    bool isGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, gameObject.transform.localScale.y+.1f, 256);
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
