using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Paused;
    public GameObject PauseSound;
    public GameObject PauseControls;
    public bool IsPaused = false;
    public float paused = 1f;

    [SerializeField] private Player player;
    private int PlayerIDNew;
    private GameObject[] players2;

    // Start is called before the first frame update
    void Start()
    {
        //sets the timescale to 1 incase scene loads paused
        Time.timeScale = 1f;

        players2 = GameObject.FindGameObjectsWithTag("Player");

        //PlayerIDNew = GetComponent<PlayerInput>().PlayerID;
        

        //for (int i = 0; , i++)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        
        for (int i = 0; i < players2.Length; i++)
        {
            //Debug.Log("THIS" + i);
            player = ReInput.players.GetPlayer(i);
            //Debug.Log("ALSOTHIS" + i);



            if (player.GetButtonDown("Menu"))
            {
                
                //checks to see if the game isn't paused
                if (IsPaused == false)
                {
                    //pauses game by setting time to 0
                    Time.timeScale = 0f;
                    //sets the pause menu gameobjects to active
                    PausePanel.transform.gameObject.SetActive(true);

                    Paused.transform.gameObject.SetActive(true);

                    PauseSound.transform.gameObject.SetActive(false);

                    PauseControls.transform.gameObject.SetActive(false);
                    //sets the paused boolean to true
                    IsPaused = true;
                }

                //if the game was paused...
                else
                {
                    //sets the time back to 1, unpausing it
                    Time.timeScale = 1f;
                    //deactivates pause menu Panel
                    PausePanel.transform.gameObject.SetActive(false);
                    //sets paused boolean to false
                    IsPaused = false;
                }
            }
        }

        //sets the pause float equal to the timescale
        paused = Time.timeScale;
        //turns the pause float into a playerpref
        PlayerPrefs.SetFloat("Paused", paused);
    }

    //creates a function that is called from a button in game
    public void ResumeGame()
    {
        //sets the timescale to 1 incase scene loads paused
        Time.timeScale = 1f;
        //deactivates pause menu gameobjects
        PausePanel.transform.gameObject.SetActive(false);
        //sets paused boolean to false
        IsPaused = false;
    }

    public void BackGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");


    }
}
