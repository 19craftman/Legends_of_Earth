using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ControllerFinder : MonoBehaviour
{
    public static event System.Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent;
    public Controller[] activecontrollers;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

    }
   
}
