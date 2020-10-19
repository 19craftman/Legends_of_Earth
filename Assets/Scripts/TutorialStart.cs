using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    public static int modifier;
    // Start is called before the first frame update
    void Start()
    {
        modifier = Random.Range(0, 3);
        GetComponent<SpawnPlayer>().Spawn();
        GetComponent<ApplyModifier>().Apply(modifier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
