using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialPanels : MonoBehaviour
{
    public GameObject[] panels;
    public int ActivePanel = 0;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        
    }

    public void NextPanel()
    {
        if (Timer <= 0)
        {
            Debug.Log(ActivePanel);
            ActivePanel++;
            panels[ActivePanel - 1].transform.gameObject.SetActive(false);
            panels[ActivePanel].transform.gameObject.SetActive(true);
        }
        
        

        if (ActivePanel >= 6)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
