using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Collider2D detect;
    // Start is called before the first frame update
    void Start()
    {
        // detect = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("in water");
    }
    // Update is called once per frame
    void Update()
    {
        // if()

    }
}