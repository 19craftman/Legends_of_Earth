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
    private int play;
    //Scene manager
    public void Start()
    {
        PlayerPrefs.SetInt("CavemanPoints", 0);
        PlayerPrefs.SetInt("PrincessPoints", 0);
        PlayerPrefs.SetInt("CowboyPoints", 0);
        PlayerPrefs.SetInt("RobotPoints", 0);
        PlayerPrefs.SetInt("Scored", 0);

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

            SceneManager.LoadScene("PlayerSelect");
        }
    }

    public void PlayGame2()
    {
        PlayerPrefs.SetString("course", "ObsCourse");
        //changes the scene to the Game scene
        SceneManager.LoadScene("PlayerSelect");

    }

    public void PlayGame3()
    {
        PlayerPrefs.SetString("course", "HotPotato");
        //changes the scene to the Game scene
        SceneManager.LoadScene("PlayerSelect");
    }

    public void Instructions()
    {
        //changes the scene to the Game scene
        SceneManager.LoadScene("Tutorial");
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToTrello()
    {
        Application.OpenURL("https://trello.com/b/wcyNkpDM/gdd410-group-project");
    }
    public void scoredGame()
    {
        play = 1;
        PlayerPrefs.SetInt("Scored", play);
        SceneManager.LoadScene("PlayerSelect");
    }
    //public void ReloadGame()
    //{
    //SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    //}
}
