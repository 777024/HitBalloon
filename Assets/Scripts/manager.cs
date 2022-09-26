using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Vector3 playerPos;
    Camera cameraM;
    Vector3 viewPos;
    void Start()
    {
        player = GameObject.Find("Player");
        cameraM = Camera.main;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        viewPos = cameraM.WorldToViewportPoint(playerPos);
        if(viewPos.x < 0 || viewPos.x > 1){
            Debug.Log("out");
            Destroy(player);
        }
        
    }
}
