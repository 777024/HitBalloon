using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    float velocityMove = 5;
    float velocityDown = 3;
    // Start is called before the first frame update
    void Start()
    {   
        Balloon balloon = gameObject.AddComponent(typeof(Balloon)) as Balloon;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = 0;
        if(Input.GetButton("Jump")){
            y = velocityMove;
        }else{
            y = -velocityDown;
        }
        Vector3 move = transform.right * x + transform.up * y;
        playerRigidbody.velocity = move;
        
        
    }
}
