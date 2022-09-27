using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int balloonNumer = 3;
    string gameObjecttag;
    float second = 4;
    ArrayList ballon = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player")
        {
            balloonNumer = 2;
            gameObjecttag = "Player";
            for (int i = 2; i < 4; i++)
            {
                ballon.Add(gameObject.transform.GetChild(i).gameObject);
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            balloonNumer = 0;
            gameObjecttag = "Enemy";
            ballon.Add(gameObject.transform.GetChild(2).gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (balloonNumer == 0)
        {
            if (gameObjecttag == "Enemy")
            {
                ((GameObject)ballon[0]).SetActive(false);
                gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;//active head trigger
                second -= Time.deltaTime;
                if (second < 0)
                {
                    balloonNumer = 1;
                    second = 3;
                }
            }
            else if (gameObjecttag == "Player")
            {
                Destroy(gameObject);//no balloon sudden death
                // Debug.Log(gameObject.transform.GetChild(1).gameObject);
            }
        }
        else if (balloonNumer < 0)
        {
            balloonNumer = 0;
        }
        else if (balloonNumer == 1)
        {
            if (gameObjecttag == "Enemy")
            {
                gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;//deactive head trigger
                ((GameObject)ballon[0]).SetActive(true);
            }

            if (gameObjecttag == "Player")
            {
                ((GameObject)ballon[1]).SetActive(false);
            }
        }
    }
}
