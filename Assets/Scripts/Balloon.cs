using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int balloonNumer = 3;
    string gameObjecttag;
    float second = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player"){
            balloonNumer = 2;
            gameObjecttag = "Player";
        }else if(gameObject.tag == "Enemy"){
            balloonNumer = 1;
            gameObjecttag = "Enemy";
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (balloonNumer == 0)
        {
            if(gameObjecttag == "Enemy"){
                second -= Time.deltaTime;
                if (second < 0)
                {
                    balloonNumer = 1;
                    second = 4;
                }
            }
            if (gameObjecttag == "Player")
            {
                Destroy(gameObject);
            }
        }
        if (balloonNumer == -1)
        {
            if(gameObjecttag == "Enemy"){
                Destroy(gameObject);
            }
        }
    }
}
