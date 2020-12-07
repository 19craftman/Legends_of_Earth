using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFiring : MonoBehaviour
{
    // public List<GameObject> lasers = new List<GameObject>();
    // public List<GameObject> laserprep = new List<GameObject>();
    // public List<GameObject> lasersFire = new List<GameObject>();
    public GameObject[] lasers;
    private LaserController[] laserControllers;
    public GameObject[] laserstop;
    private LaserController[] laserTopControllers;
    private float timer = 5;
    private float diffiulty = 0;
    private float count;
    private float counttop;
    private int rand;
    private int previous;
    private int previoustop;
    private float speed;

    public AudioSource PrepSound;
    public AudioSource FireSound;

    // Start is called before the first frame update
    void Start()
    {
        lasers = GameObject.FindGameObjectsWithTag("Laser");
        laserstop = GameObject.FindGameObjectsWithTag("LaserTop");

        laserControllers = new LaserController[lasers.Length];
        laserTopControllers = new LaserController[laserstop.Length];

        for (int i = 0; i < lasers.Length; i++)
        {
            laserControllers[i] = lasers[i].GetComponent<LaserController>();
            laserControllers[i].off();
        }

        for (int i = 0; i < laserstop.Length; i++)
        {
            laserTopControllers[i] = laserstop[i].GetComponent<LaserController>();
            laserTopControllers[i].off();
        }
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log(speed);
        speed = 5 - (diffiulty / 2);

        count = Mathf.Round(1 + (diffiulty / 2));
        counttop = Mathf.Round(1 + (diffiulty / 2));
        if (count > lasers.Length - 1)
        {
            count = lasers.Length - 1;
        }
        if (counttop > laserstop.Length - 1)
        {
            counttop = laserstop.Length - 1;
        }
        if (speed <= 3.5)
        {
            speed = 3.6f;

        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {

            // Debug.Log("Hello");
            //StartCoroutine(Prep());
            // StartCoroutine(Fire());
            // lasersFire[rand].SetActive(false);
            PrepSound.Play();
            for (int i = 0; i < count; i++)
            {
                rand = Random.Range(0, lasers.Length);

              
            
              StartCoroutine(Prep(rand, laserControllers));

            }
            for (int i = 0; i < counttop; i++)
            {
                rand = Random.Range(0, laserTopControllers.Length);

         
                    StartCoroutine(Prep(rand, laserTopControllers));

            


            }

            timer = speed;
        }


    }
    IEnumerator Prep(int rand, LaserController[] arr)
    {

        arr[rand].prep();
        yield return new WaitForSeconds(2);
        FireSound.Play();
        arr[rand].fire();
        yield return new WaitForSeconds(1);
        arr[rand].off();
        diffiulty = diffiulty + .1f;
        Debug.Log(speed);

    }

    //StartCoroutine(Fire(rand,arr,arr2));
    IEnumerator Fire(int rand, GameObject[] arr, GameObject[] arr2)

    {

        arr[rand].SetActive(false);
        arr2[rand].SetActive(true);
        yield return new WaitForSeconds(1);
        arr2[rand].SetActive(false);
        diffiulty++;
    }
}