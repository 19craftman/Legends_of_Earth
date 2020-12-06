using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class DeathCountDown : MonoBehaviour
{
    public float totalTime;
    public float increaseTimeBy;
    public float remainingTime;
    private Rigidbody2D rb;
    public Image countDownBar;
    public string deathtag;
    private string time;

    Rect box;

    private Vector2 position;

    bool grounded = false;
    bool falling = false;

    int verticleRays = 5;
    float marginX = .05f;
    float marginY = .05f;

    bool hold = false;
    [SerializeField] private Player player;
    private int PlayerIDNew;

    public AudioSource ChargeUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //time = GetComponent<PlayerInput>().time;
        countDownBar = GameObject.FindGameObjectWithTag(deathtag).GetComponent<Image>();
        CountDown.Count += decreaseTime;
        remainingTime = totalTime;
        PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        player = ReInput.players.GetPlayer(PlayerIDNew);
    }

    // Update is called once per frame
    void Update()
    {
        box = new Rect(
            GetComponent<BoxCollider2D>().bounds.min.x,
            GetComponent<BoxCollider2D>().bounds.min.y,
            GetComponent<BoxCollider2D>().bounds.size.x,
            GetComponent<BoxCollider2D>().bounds.size.y
            );

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
            }

        }

        countDownBar.fillAmount = remainingTime / totalTime;
        if (remainingTime <= 0f)
        {

            //kill player
            GameObject a = Instantiate(gameObject.GetComponent<PlayerInput>().dead);
            a.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
        }
        if (!hold && grounded && gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero && player.GetAxis("Recharge") >= .1)
        {
            if (remainingTime < totalTime)
            {
                position = transform.position;
                if (gameObject.GetComponent<BaseMove>() != null)
                {
                    gameObject.GetComponent<BaseMove>().enabled = false;
                }
                else if (gameObject.GetComponent<MoveInAir>() != null)
                {
                    gameObject.GetComponent<MoveInAir>().enabled = false;
                }
                if (gameObject.GetComponent<BaseJump>() != null)
                {
                    gameObject.GetComponent<BaseJump>().enabled = false;
                }
                else if (gameObject.GetComponent<DoubleJump>() != null)
                {
                    gameObject.GetComponent<DoubleJump>().enabled = false;
                }
                hold = true;
            }
        }
        else if (hold && player.GetAxis("Recharge") == 0 && remainingTime == totalTime)
        {
            hold = false;
            ChargeUp.Play();
            if (gameObject.GetComponent<BaseMove>() != null)
            {
                gameObject.GetComponent<BaseMove>().enabled = true;
            }
            else if (gameObject.GetComponent<MoveInAir>() != null)
            {
                gameObject.GetComponent<MoveInAir>().enabled = true;
            }
            if (gameObject.GetComponent<BaseJump>() != null)
            {
                gameObject.GetComponent<BaseJump>().enabled = true;
            }
            else if (gameObject.GetComponent<DoubleJump>() != null)
            {
                gameObject.GetComponent<DoubleJump>().enabled = true;
            }
        }

        if (hold)
        {
            increaseTime();
            transform.position = position;
        }
    }

    void decreaseTime(float time)
    {
        if (!hold && Mathf.Abs(rb.velocity.x) > 0)
        {
            remainingTime -= time;

        }

    }

    public void increaseTime()
    {
        if (remainingTime + increaseTimeBy < totalTime)
        {
            remainingTime += increaseTimeBy;
        }
        else
        {
            remainingTime = totalTime;
        }
    }

    private void OnDestroy()
    {
        CountDown.Count -= decreaseTime;
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
