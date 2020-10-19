using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplyModifier : MonoBehaviour
{
    
    public TextMeshProUGUI modString;
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
        switch (mod)
        {
            case 2:
                modString.text = "Move in air";
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseMove>());
                    a.AddComponent<MoveInAir>();
                }
                break;
            case 1:
                modString.text = "Double Jump";
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseJump>());
                    a.AddComponent<DoubleJump>();
                }
                break;
            case 0:
                modString.text = "Player Swap";
                gameObject.AddComponent<PlayerSwap>();
                gameObject.GetComponent<PlayerSwap>().totalTime =5;
                break;
            default:
                break;
        }
    }
}
