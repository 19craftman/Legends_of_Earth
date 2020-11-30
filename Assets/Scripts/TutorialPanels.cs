using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialPanels : MonoBehaviour
{
    public GameObject[] panels;
    public int ActivePanel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPanel()
    {


        ActivePanel++;
        panels[ActivePanel].transform.gameObject.SetActive(true);
        panels[ActivePanel - 1].transform.gameObject.SetActive(false);

        if (ActivePanel >= 7)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
