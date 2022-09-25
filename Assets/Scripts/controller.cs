using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Balloon balloon;
    float velocityHrizntl = 3;
    float velocityVrtikl = 4;
    // float gravity = -3;
    float timeToStop = 2;
    // Start is called before the first frame update
    void Start()
    {   
        balloon = gameObject.AddComponent(typeof(Balloon)) as Balloon;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = 0;
        float y = 0;
        
        if(Input.GetButton("Jump")){
            timeToStop -= Time.deltaTime;
            if (timeToStop < 0)
            {
                playerRigidbody.drag = 0;    
            }
            playerRigidbody.drag = 0;
            y = velocityVrtikl;
            
        }
        else{
            timeToStop = 1;
            y = -3;
            if (balloon.balloonNumer == 2)
            {
                playerRigidbody.drag = 3;
            }else if(balloon.balloonNumer == 1){
                playerRigidbody.drag = 1;
            }
        }

        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetButton("Jump") && Input.GetButton("Horizontal"))
            {
                playerRigidbody.drag = 0;
                x = Input.GetAxis("Horizontal") * velocityHrizntl;
            }else
            {
                x = Input.GetAxis("Horizontal") * velocityHrizntl * 3;
                if (balloon.balloonNumer == 2)
                {
                    playerRigidbody.drag = 3;
                }else if(balloon.balloonNumer == 1){
                    playerRigidbody.drag = 1;
                }
            }
        }
        Vector3 move = transform.right * x + transform.up * y;
        playerRigidbody.AddForce(move);
        
    }
}
