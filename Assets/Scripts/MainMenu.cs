using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Player player;
    private float timer;
    //Scene manager
    public void Start()
    {
        timer = 1;
        player = ReInput.players.GetPlayer(0);
    }
    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
    }
    //creates a function that is called from a button in game
    public void BackGame()
    {
        Time.timeScale = 1f;

      
        //changes the scene to the menu scene
        SceneManager.LoadScene("MainMenu");


    }

    //creates a function that is called from a button in game

    public void PlayGame()
    {

        if (timer <=0)
        {
            PlayerPrefs.SetString("course", "Lazers");
            //changes the scene to the Game scene

            SceneManager.LoadScene("SelectMini");
        }
    }

    public void PlayGame2()
    {
        PlayerPrefs.SetString("course", "ObsCourse");
        //changes the scene to the Game scene
        SceneManager.LoadScene("SelectMini");

    }

    public void Instructions()
    {
        //changes the scene to the Game scene
        SceneManager.LoadScene("Instructions");
    }

    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame()
    {
        //reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    }
}
