using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFiring : MonoBehaviour
{
    // public List<GameObject> lasers = new List<GameObject>();
    // public List<GameObject> laserprep = new List<GameObject>();
    // public List<GameObject> lasersFire = new List<GameObject>();
    public GameObject[] lasers;
    public GameObject[] laserprep;
    public GameObject[] lasersFire;
    public GameObject[] laserstop;
    public GameObject[] laserpreptop;
    public GameObject[] lasersFiretop;
    private float timer = 6;
    private float diffiulty = 0;
    private float count;
    private float counttop;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        lasers = GameObject.FindGameObjectsWithTag("Laser");
        laserprep = GameObject.FindGameObjectsWithTag("PrepLaser");
        lasersFire = GameObject.FindGameObjectsWithTag("Fire");
        laserstop = GameObject.FindGameObjectsWithTag("LaserTop");
        laserpreptop = GameObject.FindGameObjectsWithTag("PrepLaserTop");
        lasersFiretop = GameObject.FindGameObjectsWithTag("FireTop");
        for (int i = 0; i < lasersFire.Length; i++)
        {
            lasersFire[i].SetActive(false);
        }
        for (int i = 0; i < laserprep.Length; i++)
        {
            laserprep[i].SetActive(false);
        }
        for (int i = 0; i < lasersFiretop.Length; i++)
        {
            lasersFiretop[i].SetActive(false);
        }
        for (int i = 0; i < laserpreptop.Length; i++)
        {
            laserpreptop[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
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


            for (int i = 0; i < count; i++)
            {
             rand = Random.Range(0, lasers.Length);
                StartCoroutine(Prep(rand,laserprep,lasersFire));


            }
            for (int i = 0; i < counttop; i++)
            {
                rand = Random.Range(0, laserstop.Length);
                StartCoroutine(Prep(rand, laserpreptop, lasersFiretop));


            }
            timer = 6;
        }
      

}
    IEnumerator Prep(int rand,GameObject[] arr, GameObject[] arr2)
       
    {
    
        arr[rand].SetActive(true);
        yield return new WaitForSeconds(4.7f);
        arr[rand].SetActive(false);
        arr2[rand].SetActive(true);
        yield return new WaitForSeconds(1);
        arr2[rand].SetActive(false);
        diffiulty = diffiulty +.1f; 
        //StartCoroutine(Fire(rand,arr,arr2));
    }
    IEnumerator Fire(int rand, GameObject[] arr, GameObject[] arr2)

    {
    
        arr[rand].SetActive(false);
        arr2[rand].SetActive(true);
        yield return new WaitForSeconds(1);
        arr2[rand].SetActive(false);
        diffiulty++;
    }
}

