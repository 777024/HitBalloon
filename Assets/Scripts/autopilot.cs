using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autopilot : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;
    Balloon balloon;
    float velocity = 2;
    Vector3 move;
    float second = 0;
    // Start is called before the first frame update
    void Start()
    {
        balloon = gameObject.AddComponent(typeof(Balloon)) as Balloon;
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.drag = 3;
        move = transform.up * velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (balloon.balloonNumer == 1)
        {
            second -= Time.deltaTime;
            if (second < 0 && second > -2)
            {
                enemyRigidbody.velocity = move;
            }
            else if(second < -2)
            {
                second = 2;
            }
                // enemyRigidbody.velocity = 0 * transform.up;
        }
    }
}
