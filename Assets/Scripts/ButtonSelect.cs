using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Rewired;

public class ButtonSelect : MonoBehaviour
{
    private Button SelectThis;
    //private Button DisableButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SelectThis = this.gameObject.GetComponent<Button>();
        //DisableButton = GameObject.FindGameObjectWithTag("DisableButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //DisableButton.Select();
        //Debug.Log("hi");
        SelectThis.Select();
        SelectThis.OnSelect(null);
        
    }

    
}
