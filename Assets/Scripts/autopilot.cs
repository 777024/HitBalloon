using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autopilot : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;
    Balloon balloon;
    float velocity = 3;
    Vector3 move;
    float second;
    // Start is called before the first frame update
    void Start()
    {
        balloon = gameObject.AddComponent(typeof(Balloon)) as Balloon;
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.drag = 1;
        move = transform.up * velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(balloon.balloonNumer == 1){
            second -= Time.deltaTime;
            if (second < 0)
            {
                if (Random.value > 0.5)
                {
                    for (float i = 0; i < 2; i += Time.deltaTime)
                    {
                        enemyRigidbody.AddForce(move);
                    }
                }else{
                    second = 2;
                }
            }
        }
    }
}
