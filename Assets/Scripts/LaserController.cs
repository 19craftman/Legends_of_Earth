using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserPrep;
    public GameObject laserFire;

    public void prep()
    {
        laserFire.SetActive(false);
        laserPrep.SetActive(true);
    }

    public void fire()
    {
        laserPrep.SetActive(false);
        laserFire.SetActive(true);
    }

    public void off()
    {
        laserFire.SetActive(false);
        laserPrep.SetActive(false);
    }
}
