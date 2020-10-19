using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CountDown : MonoBehaviour
{
    public static event Action<float> Count = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count(Time.deltaTime);
    }
}
