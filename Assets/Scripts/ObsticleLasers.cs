using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleLasers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] laserstop;
    private LaserController[] laserTopControllers;
    private float timer;
    private int rand;

    public AudioSource PrepSound;
    public AudioSource FireSound;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(4, 6);
        laserstop = GameObject.FindGameObjectsWithTag("LaserTop");
        laserTopControllers = new LaserController[laserstop.Length];
        for (int i = 0; i < laserstop.Length; i++)
        {
            laserTopControllers[i] = laserstop[i].GetComponent<LaserController>();
            laserTopControllers[i].off();
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(timer);

        if (timer > 0)
        {

            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            
            PrepSound.Play();
            for (int i = 0; i < laserstop.Length; i++)
            {
                rand = Random.Range(0, laserTopControllers.Length);


                StartCoroutine(Prep(rand, laserTopControllers));



            }
            timer = Random.Range(4, 6);
        }
    }
    IEnumerator Prep(int rand, LaserController[] arr)
    {

        yield return new WaitForSeconds(Random.Range(2, 4));

        arr[rand].prep();
        yield return new WaitForSeconds(2);
        FireSound.Play();
        arr[rand].fire();
        yield return new WaitForSeconds(1);
        arr[rand].off();

    }
}
