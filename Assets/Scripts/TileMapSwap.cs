using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapSwap : MonoBehaviour
{

    public float Countdown = 10f;
    public GameObject Red;
    public GameObject Green;
    public bool Flip = false;

    public AudioSource PlatformSwapSound;
    public AudioSource PlatformSwappingSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;

        if (Countdown <= 2.5 && Countdown > 2 && !PlatformSwappingSound.isPlaying)
        {
            PlatformSwappingSound.Play();
        }

        if (Countdown <= 0)
        {
            PlatformSwapSound.Play();
            Countdown = 10;
            if (Flip == false)
            {
                Flip = true;
            }
            else
            {
                Flip = false;
            }
        }

        if (Flip == true)
        {
            Red.SetActive(true);
            Green.SetActive(false);
        }
        if (Flip == false)
        {
            Red.SetActive(false);
            Green.SetActive(true);
        }
    }
}
