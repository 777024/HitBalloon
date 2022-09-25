using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int balloonNumer = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player"){
            balloonNumer = 2;
        }else if(gameObject.tag == "Enemy"){
            balloonNumer = 1;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
