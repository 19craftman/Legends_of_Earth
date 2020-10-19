using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ModInstructions : MonoBehaviour
{
    public int Count = 0;
    public TextMeshProUGUI ModName;
    public TextMeshProUGUI ModDesc;
    public TextMeshProUGUI PlayerDesc;
    public GameObject PlayerInst;
    public GameObject ModInst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Count);
    }

    public void ModTutorial()
    {
        Count++;
        if (Count == 0)
        {
            PlayerDesc.text = "Use the Joystick to move side to side";
        }
        if (Count == 1)
        {
            PlayerDesc.text = "Hit X to jump";
        }
        if (Count == 2)
        {
            PlayerDesc.text = "As you move, your Time Discrepancy Bar depletes, hold SQUARE to recharge it or you will die";
        }
        if (Count == 3)
        {
            PlayerInst.transform.gameObject.SetActive(false);
            ModInst.transform.gameObject.SetActive(true);
        }
        if (Count == 3)
        {
            ModName.text = "Modifier: Double Jump";
            ModDesc.text = "Players have access to two jumps! Jumps reset everytime they hit the floor";
        }
        if (Count == 4)
        {
            ModName.text = "Modifier: Move In Air";
            ModDesc.text = "Players are unable to move while touching the ground";
        }
        if (Count == 5)
        {
            ModName.text = "Modifier: Player Swap";
            ModDesc.text = "Each player will swap postions with eachother at set intervals of time.";
        }
        if (Count == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
