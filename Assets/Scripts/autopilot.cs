using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sutopilot : MonoBehaviour
{
    double velocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        Balloon balloon = gameObject.AddComponent(typeof(Balloon)) as Balloon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
