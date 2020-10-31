using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Scene manager

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
        //changes the scene to the Game scene
        SceneManager.LoadScene("Lazers");
    }

    public void PlayGame2()
    {
        //changes the scene to the Game scene
        SceneManager.LoadScene("ObsCourse");
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
