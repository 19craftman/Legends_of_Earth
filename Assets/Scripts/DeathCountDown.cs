using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCountDown : MonoBehaviour
{
    public float totalTime;
    public float increaseTimeBy;
    public float remainingTime;
    private Rigidbody2D rb;
    public Image countDownBar;
    public string deathtag;
    private string time;

    bool hold = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        time = GetComponent<PlayerInput>().time;
        countDownBar = GameObject.FindGameObjectWithTag(deathtag).GetComponent<Image>();
        CountDown.Count += decreaseTime;
        remainingTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        countDownBar.fillAmount = remainingTime / totalTime;
        if(remainingTime<=0f)
        {
            
            //kill player
            gameObject.SetActive(false);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity == Vector2.zero && Input.GetAxisRaw(time) ==1)
        {
            if(remainingTime<totalTime)
            {
                increaseTime();
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
        else if(hold && Input.GetAxisRaw(time) == 0 && remainingTime==totalTime)
        {
            hold = false;
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
    }

    void decreaseTime(float time)
    {
        if(!hold&& Mathf.Abs(rb.velocity.x) > 0)
        {
            remainingTime -= time;
            
        }
        
    }

    void increaseTime()
    {
        if(remainingTime+increaseTimeBy < totalTime)
        {
            remainingTime+=increaseTimeBy;
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
}
