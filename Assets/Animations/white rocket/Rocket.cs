using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rocket : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject[] buttons;
    public GameObject rocket;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //rocket.transform.position = new Vector2(rocket.transform.position.x,
        //    buttons[index].transform.position.y);
        //if(Input.GetKeyDown(KeyCode.DownArrow) && index>0)
        //{
        //    index--;
        //}
        //if
    }
}
