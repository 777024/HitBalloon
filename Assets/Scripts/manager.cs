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
    Vector3 leftBorder;
    Vector3 rightBorder;
    void Start()
    {
        player = GameObject.Find("Player");
        cameraM = Camera.main;
        leftBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(-0.03f, 0)).x, 0, 0);
        rightBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(1.03f, 0)).x, 0, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerPos = player.transform.position;
            viewPos = cameraM.WorldToViewportPoint(playerPos);
            if(viewPos.x < -0.03){
                Debug.Log("out");
                // Destroy(player);
                player.transform.localPosition += 2 * rightBorder;
            }else if (viewPos.x > 1.03)
            {
                Debug.Log("out");
                // Destroy(player);
                player.transform.localPosition += 2 * leftBorder;
            }
        }
        
        
    }
}
