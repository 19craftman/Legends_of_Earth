using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rewired;
using UnityEngine.EventSystems;

public class FindSelectedButton : MonoBehaviour
{
    public EventSystem EventSystemName;
    private void Awake()
    {
        EventSystemName.SetSelectedGameObject(EventSystemName.firstSelectedGameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //GameObject.Find(EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(EventSystemName.currentSelectedGameObject.name);
    }
}
