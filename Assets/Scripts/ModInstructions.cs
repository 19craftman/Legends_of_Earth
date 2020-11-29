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
            PlayerDesc.text = "Hit X to jump. If there is a platform above you, you will short jump instead";
        }
        if (Count == 2)
        {
            PlayerDesc.text = "As you move, your Time Discrepancy Bar depletes, hold SQUARE to recharge it or you will die (you cannot move while recharging)";
        }
        if (Count == 3)
        {
            PlayerDesc.text = "Press the START button to open the Pause Menu";
        }
        if (Count == 4)
        {
            PlayerInst.transform.gameObject.SetActive(false);
            ModInst.transform.gameObject.SetActive(true);
        }
        if (Count == 4)
        {
            ModName.text = "Modifier: Double Jump";
            ModDesc.text = "Players have access to two jumps! Jumps reset everytime they hit the floor";
        }
        if (Count == 5)
        {
            ModName.text = "Modifier: Icy";
            ModDesc.text = "The floors are covered in Ice! The players now slide when they move on the ground";
        }
        if (Count == 6)
        {
            ModName.text = "Modifier: Flappy";
            ModDesc.text = "Players can jump MANY times in a row, however each jump is very small!";
        }
        if (Count == 7)
        {
            ModName.text = "Modifier: JetPack";
            ModDesc.text = "Each player is equiped with a JetPack! Hold jump to lift off! Recharge your Jetpack by landing on the ground";
        }
        if (Count == 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
