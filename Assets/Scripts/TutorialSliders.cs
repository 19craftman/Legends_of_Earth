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
            MiniText.text = "The Players find themselves trapped in a room covered in lasers. As time goes on, more lasers will activate and the lasers will speed up. Dodge the lasers until you are the last one left!";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/LasersPic");
        }

        if (MiniCount == 2)
        {
            MiniName.text = "< Obstacle Course >";
            MiniText.text = "The players find themselves on a deadly obstacle course. They must make their way to the end of the course and reach the goal first to win! Be careful, if a player falls on a spike, is hit by a laser, or falls off the screen they will die! The player who made it the furthest will be declared the winner.";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/ObPic");
        }

        if (MiniCount == 3)
        {
            MiniName.text = "< Hot Potato >";
            MiniText.text = "The players are trapped in a room with ever changing terrain… and a potato bomb! They have to tag each other to pass off the Hot Potato Bomb before the potato's timer runs out and explodes!";
            MiniPicture.sprite = Resources.Load<Sprite>("MiniGames/PotatoPic");
        }

    }

    public void ModifierSlider(float ModCount)
    {

        if (ModCount == 1)
        {
            ModName.text = "< Icy Floors >";
            ModText.text = "The floors are covered in Ice! wait why does it look like it's still just metal?";
        }

        if (ModCount == 2)
        {
            ModName.text = "< Low Gravity >";
            ModText.text = "Whoa, why am I not falling as fast? Low gravity must be on.";
        }

        if (ModCount == 3)
        {
            ModName.text = "< JetPack >";
            ModText.text = "We're equipped with a JetPack! Hold jump to lift off! Recharge by landing.";
        }
        if (ModCount == 4)
        {
            ModName.text = "< Double Jump >";
            ModText.text = "Jumping twice? What's the physics behind that?";
        }

        if (ModCount == 5)
        {
            ModName.text = "< Flappy Jump >";
            ModText.text = "Okay now you're just messing with me";
        }


        if (ModCount == 6)
        {
            ModName.text = "< Double Speed >";
            ModText.text = "Might get kicked out of a normal sport if they caught you doing this";
        }
       
    }
}
