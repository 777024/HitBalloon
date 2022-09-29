using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScore : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigidbody2d;
    CircleCollider2D circleCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

   private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.name == "Player")
    {
        gameObject.SetActive(false);
        ScorePlus300();
    }
   }
    void FixedUpdate()
    {
        rigidbody2d.velocity =new Vector3(0, 3, 0);

    }

    void ScorePlus300() {
        Manager.score += 300;
        Manager.text.text = "Score : " + Manager.score;
    }
}