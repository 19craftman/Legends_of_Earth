using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   
    public string character;
    public int PlayerID;
    public string characterpoints;
    public int points;

    public void Awake()
    {
        PlayerID = PlayerPrefs.GetInt(character);
        points = PlayerPrefs.GetInt(characterpoints);
    }
}
