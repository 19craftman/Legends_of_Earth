using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialSliders : MonoBehaviour
{
    public SpriteRenderer MiniPicture;
    public TextMeshProUGUI MiniName;
    public TextMeshProUGUI MiniText;

    //public GameObject ModPicture;
    public TextMeshProUGUI ModName;
    public TextMeshProUGUI ModText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinigameSlider(float MiniCount)
    {
        Debug.Log(MiniCount);
        if (MiniCount == 1)
        {
            MiniName.text = "< Lasers >";
            MiniText.text = "The Players find themselves trapped in a room covered in lasers. As time goes on, more lasers will activate and the lasers will speed up. The players’ goal is to dodge the lasers until they are the last one left.";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/LasersPic");
        }

        if (MiniCount == 2)
        {
            MiniName.text = "< Obstacle Course >";
            MiniText.text = "The players find themselves in a continuous room full of traps and various paths. The players must make their way to the end of the course and reach the goal first to win! Be careful, if a player falls on a spike, is hit by a laser, or falls off the screen they will die! If all players die, the player who made it the furthest will be declared the winner.";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/ObPic");
        }

        if (MiniCount == 3)
        {
            MiniName.text = "< Hot Potato >";
            MiniText.text = "the players are trapped in a room with ever changing terrain… and a potato bomb! The players will have to tag each other to pass off the Hot Potato Bomb before the bomb's timer runs out and kills them! They should also pay attention for the map to change as they play.";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/PotatoPic");
        }

    }

    public void ModifierSlider(float ModCount)
    {

        if (ModCount == 1)
        {
            ModName.text = "< Double Jump >";
            ModText.text = "Players have access to two jumps! Jumps reset every time they hit the floor";
        }

        if (ModCount == 2)
        {
            ModName.text = "< Icy >";
            ModText.text = "The floors are covered in Ice! The players now slide when they move on the ground";
        }

        if (ModCount == 3)
        {
            ModName.text = "< Flappy >";
            ModText.text = "Players can jump MANY times in a row, however each jump is very small!";
        }

        if (ModCount == 4)
        {
            ModName.text = "< JetPack >";
            ModText.text = "Each player is equipped with a JetPack! Hold jump to lift off! Recharge your Jetpack by landing on the ground";
        }
    }
}
