 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerSelecting : MonoBehaviour
{

   // [SerializeField] private Player player;
    private int PlayerIDNew;
    public GameObject[] PlayerDot;
    public float speed = 100;
    private string horizontal;
    public GameObject[] Selections;
    public GameObject[] currentlyActive;
    public GameObject[] selectedChar;
    public Sprite[] characters;
    public static List<GameObject> players = new List<GameObject>();
    public GameObject[] prefabs;
    public static List<GameObject> playersScoring = new List<GameObject>();
    public GameObject[] prefabsScoring;

    //public List<GameObject> PlayerDot = new List<GameObject>();
    private List<int> currentlyin = new List<int>();
    private bool CanStartGame = false;
    private int count = 0;
    private static int playernumber = 0;
    public TextMeshProUGUI[] playermenu;

    private Camera theCamera;

    
    
    // Start is called before the first frame update
  
    void Start()
    {
        theCamera = FindObjectOfType<Camera>();
        players.Clear();
        playersScoring.Clear();
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
            
                if (ReInput.players.GetPlayer(i).GetButtonDown("Submit"))
                {
                    PlayerDot[i].SetActive(true);
                    playermenu[i].text = "Press X to Select Player";
                    currentlyin.Add(i);
               
                    count++;

                    PlayerPrefs.SetInt("inGame", count);
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            
            if (ReInput.players.GetPlayer(i).GetButtonDown("Submit"))
            {
                //Debug.Log("helloooo");
                if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[0].GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("Caveman");
                    PlayerPrefs.SetInt("Caveman", i);
                    selectedChar[i].GetComponent<SpriteRenderer>().sprite = characters[0];
                    playermenu[i].text = "READY!";
                    PlayerDot[i].SetActive(false);
                    // PlayerDot.Remove(PlayerDot[i]);
                    //Destroy(PlayerDot[i]);
                    players.Add(prefabs[0]);
                    playersScoring.Add(prefabsScoring[0]);

                    Selections[0].SetActive(false);
                }
                else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[1].GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("Princess");
                    selectedChar[i].GetComponent<SpriteRenderer>().sprite = characters[1];
                    PlayerPrefs.SetInt("Princess", i);
                    
                    playermenu[i].text = "READY!";
                    PlayerDot[i].SetActive(false);
                    //PlayerDot.Remove(PlayerDot[i]);
                    // Destroy(PlayerDot[i]);
                    //PlayerDot[i].SetActive(false);
                    players.Add(prefabs[1]);
                    playersScoring.Add(prefabsScoring[1]);
                    Selections[1].SetActive(false);
                }
                else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[2].GetComponent<BoxCollider2D>()))
                {
                    PlayerPrefs.SetInt("Cowboy", i);
                    selectedChar[i].GetComponent<SpriteRenderer>().sprite = characters[2];
                    
                    playermenu[i].text = "READY!";
                    PlayerDot[i].SetActive(false);
                    players.Add(prefabs[2]);
                    playersScoring.Add(prefabsScoring[2]);
                    Selections[2].SetActive(false);
                }
                else if (PlayerDot[i].GetComponent<BoxCollider2D>().IsTouching(Selections[3].GetComponent<BoxCollider2D>()))
                {
                    PlayerPrefs.SetInt("Robot", i);
                    selectedChar[i].GetComponent<SpriteRenderer>().sprite = characters[3];

                    playermenu[i].text = "READY!";
                    PlayerDot[i].SetActive(false);
                    players.Add(prefabs[3]);
                    playersScoring.Add(prefabsScoring[3]);
                    Selections[3].SetActive(false);
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
            //player = ReInput.players.GetPlayer(i);
            float horizontalInput = ReInput.players.GetPlayer(i).GetAxis("Horizontal");
            float verticleInput = ReInput.players.GetPlayer(i).GetAxis("Verticle");
            float xSpeed = PlayerDot[i].GetComponent<Rigidbody2D>().velocity.x;
            float ySpeed = PlayerDot[i].GetComponent<Rigidbody2D>().velocity.y;


            var leftCorner = theCamera.ScreenToWorldPoint(Vector3.zero);

            var rightCorner = theCamera.ScreenToWorldPoint(new Vector3(theCamera.pixelWidth, theCamera.pixelHeight));
            var newWidth = rightCorner.x - leftCorner.x;
            var newHieght = rightCorner.y - leftCorner.y;
            var cameraRect = new Rect(leftCorner.x, leftCorner.y, newWidth, newHieght);




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
            PlayerDot[i].transform.position = new Vector3(Mathf.Clamp(PlayerDot[i].transform.position.x, cameraRect.xMin, cameraRect.xMax), Mathf.Clamp(PlayerDot[i].transform.position.y, cameraRect.yMin, cameraRect.yMax), PlayerDot[i].transform.position.z);
            //Debug.Log(PlayerDot[i].GetComponent<Rigidbody2D>().velocity);

        }





    }
    private class PlayerMap
    {
        public int rewiredPlayerId;
        public int gamePlayerId;

        public PlayerMap(int rewiredPlayerId, int gamePlayerId)
        {
            this.rewiredPlayerId = rewiredPlayerId;
            this.gamePlayerId = gamePlayerId;
        }
    }
}

    