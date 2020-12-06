using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Lazers");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Scoring()
    {

        if (PlayerPrefs.GetInt("Scored") == 1)
        {
            SceneManager.LoadScene("PointScreen");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");

        }
      
    }
    public void select()
    {
        SceneManager.LoadScene("SelectMini");
    }
}
