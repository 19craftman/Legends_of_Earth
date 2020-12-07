using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteract : MonoBehaviour
{
    private Button thebutton;
    private float time;

    private void Awake()
    {
        thebutton = this.gameObject.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        time = .5f;
        thebutton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            thebutton.interactable = true;
        }
    }
}
