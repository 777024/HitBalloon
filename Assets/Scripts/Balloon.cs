using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    int ballonNumer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player"){
            ballonNumer = 2;
        }else if(gameObject.tag == "Enemy"){
            ballonNumer = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
