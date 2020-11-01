using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //creates two game objects to put the pause menu that fills the screen
    public GameObject PausePanel;

    //creates two game objects to put the pause menu that fills the screen
    public GameObject Paused;

    //creates two game objects to put the pause menu that fills the screen
    public GameObject PauseSound;

    //creates two game objects to put the pause menu that fills the screen
    public GameObject PauseControls;

    //creates a bool to see if the game is paused, starts off false
    public bool IsPaused = false;
    //creates a float that is later turned into a playerpref to see if the game is paused
    public float paused = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //sets the timescale to 1 incase scene loads paused
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

            //checks to see if the tab button is pressed
            if (Input.GetKeyDown(KeyCode.Tab))
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
}
