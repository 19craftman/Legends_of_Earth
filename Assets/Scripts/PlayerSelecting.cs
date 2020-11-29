using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerSelecting : MonoBehaviour
{

    [SerializeField] private Player player;
    private int PlayerIDNew;
    public GameObject[] PlayerDot;
    public float speed = 100;
    private string horizontal;
    public GameObject[] Selections;
    public GameObject[] currentlyActive;

    public static List<GameObject> players = new List<GameObject>();
    public GameObject[] prefabs;

    //public List<GameObject> PlayerDot = new List<GameObject>();
    private List<int> currentlyin = new List<int>();
    private bool CanStartGame = false;
    private int count =0;



    // Start is called before the first frame update
    void Start()
    {
        players.Clear();
        for (int i = 0; i < PlayerDot.Length; i++)
        {
            if (PlayerDot[i] != null)
            {
                PlayerDot[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentlyActive = GameObject.FindGameObjectsWithTag("ICON");
       
        if (count >= 2)
        {
            CanStartGame = true;
            
        }
        if (CanStartGame)
        {

            if (currentlyActive.Length <= 0)
            {
                SceneManager.LoadScene("SelectMini");
            }

        }

//for spawning in PlayerDots

        for (int i = 0; i < 4; i++)
        {
            if (!currentlyin.Contains(i))
            {
                player = ReInput.players.GetPlayer(i);
                if (player.GetButtonDown("Submit"))
                {
                    currentlyin.Add(i);
                    PlayerDot[i].SetActive(true);
                    count++;
                }
            }
       }

        for (int i = 0; i < 4; i++)
        {
            player = ReInput.players.GetPlayer(i);
            if (player.GetButtonDown("Submit"))
            {
                Debug.Log("helloooo");
                if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[0].GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("Caveman");
                    PlayerPrefs.SetInt("Caveman", i);
                    PlayerDot[i].SetActive(false);
                    // PlayerDot.Remove(PlayerDot[i]);
                    //Destroy(PlayerDot[i]);
                    players.Add(prefabs[0]);

                    Selections[0].SetActive(false);
                }
                else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[1].GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("Princess");

                    PlayerPrefs.SetInt("Princess", i);

                    PlayerDot[i].SetActive(false);
                    //PlayerDot.Remove(PlayerDot[i]);
                    // Destroy(PlayerDot[i]);
                    //PlayerDot[i].SetActive(false);
                    players.Add(prefabs[1]);
                    Selections[1].SetActive(false);
                }
                else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[2].GetComponent<BoxCollider2D>()))
                {
                PlayerPrefs.SetInt("Cowboy", i);

                PlayerDot[i].SetActive(false);
                    players.Add(prefabs[2]);
                    Selections[2].SetActive(false);
                }
                // else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[3].GetComponent<BoxCollider2D>()))
                // {

                //}
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            player = ReInput.players.GetPlayer(i);
            float horizontalInput = player.GetAxis("Horizontal");
            float verticleInput = player.GetAxis("Verticle");
            float xSpeed = PlayerDot[i].GetComponent<Rigidbody2D>().velocity.x;
            float ySpeed = PlayerDot[i].GetComponent<Rigidbody2D>().velocity.y;
            if (horizontalInput != 0)
            {
                xSpeed = horizontalInput * speed;
           //     xSpeed = Mathf.Clamp(xSpeed, -speed, speed);
            }
            else if (xSpeed != 0)
            {
                xSpeed = 0;
            }
   

            if (verticleInput != 0)
            {
                ySpeed = verticleInput * speed;
            //    ySpeed = Mathf.Clamp(ySpeed, -speed, speed);
            }
            else if (ySpeed != 0)
                ySpeed = 0;



            PlayerDot[i].GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
            //Debug.Log(PlayerDot[i].GetComponent<Rigidbody2D>().velocity);
            
        }





    }
    }
