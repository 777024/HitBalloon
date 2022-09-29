using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScore : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody2d.velocity =new Vector3(0, 3, 0);
    }
}