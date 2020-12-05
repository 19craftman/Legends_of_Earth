using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float time = 30;
    public TextMeshProUGUI timing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timing.text = "Seconds Left: " + Mathf.Round(time);
        if (time <= 0)
        {
            time = 0;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
