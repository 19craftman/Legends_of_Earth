using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   
    public string character;
    public int PlayerID;
    public string characterpoints;
    public int points;
    public GameObject dead;

    public void Awake()
    {
        
        PlayerID = PlayerPrefs.GetInt(character);
        points = PlayerPrefs.GetInt(characterpoints);
    }
    
    private void OnDisable()
    {
        if (this.enabled)
        {
            // GameObject a = Instantiate(dead);
            // a.transform.position = gameObject.transform.position;
            Debug.Log("SHADOW");
        }
    }
}
