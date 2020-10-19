using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplyModifier : MonoBehaviour
{
    
    public TextMeshProUGUI modString;
    new string[] name = { "Player Swap", "Double Jump", "Move in air" };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Apply(int mod)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(name[1]);
        switch (mod)
        {
            case 2:
                modString.text = name[2];
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseMove>());
                    a.AddComponent<MoveInAir>();
                }
                break;
            case 1:
                modString.text = name[1];
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseJump>());
                    a.AddComponent<DoubleJump>();
                }
                break;
            case 0:
                modString.text = name[0];
                gameObject.AddComponent<PlayerSwap>();
                gameObject.GetComponent<PlayerSwap>().totalTime = 5;
                break;
            default:
                break;
        }
    }
}
