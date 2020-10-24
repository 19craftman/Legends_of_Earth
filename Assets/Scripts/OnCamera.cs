using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCamera : MonoBehaviour
{

    void OnBecameInvisible()
    {
        //Debug.Log("helloThere");
        gameObject.SetActive(false);
    }
}
