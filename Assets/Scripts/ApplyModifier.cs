using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplyModifier : MonoBehaviour
{

    public TextMeshProUGUI modString;
    new string[] name = { "Flappy Jump", "Double Jump", "Icy Floors", "Jet Pack","Double Speed" };
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

            case 4:
                modString.text = name[4];
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseMove>());
                    a.AddComponent<SpeedUp>();
                }
                break;
            case 3:
                modString.text = name[3];
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseJump>());
                    a.AddComponent<JetPack>();
                }
                break;
            case 2:
                modString.text = name[2];
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseMove>());
                    a.AddComponent<Icy>();
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
                foreach (GameObject a in players)
                {
                    Destroy(a.GetComponent<BaseJump>());
                    a.AddComponent<Flappy>();
                }
                break;
            default:
                break;
        }
    }
}
