using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public EventSystem eventSystem;
    GameObject button;
    public GameObject roc;
    GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(button!=eventSystem.currentSelectedGameObject)
        {
            if(button!=null && !button.CompareTag("Slider"))
            {
                Destroy(spawn);
            }
            button = eventSystem.currentSelectedGameObject;
            if (!eventSystem.currentSelectedGameObject.CompareTag("Slider") && eventSystem.currentSelectedGameObject != null && button.activeInHierarchy == true)
            {
                
                spawn = Instantiate(roc);
                spawn.transform.SetParent(button.transform);
                RectTransform rt = spawn.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                // rt.localScale = new Vector3(30, 30, 30);
                rt.position = new Vector2(rt.position.x, button.GetComponent<RectTransform>().position.y);
            }
            
        }
    }
}
