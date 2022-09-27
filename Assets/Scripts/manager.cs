using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject[] Enemies = null;
    Vector3 enemyPos;
    Vector3 viewPosEnemy;


    GameObject player;
    Vector3 playerPos;


    Camera cameraM;
    Vector3 viewPosPlayer;


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
            viewPosPlayer = cameraM.WorldToViewportPoint(playerPos);
            if (viewPosPlayer.x < -0.03)
            {
                // Debug.Log("out");
                // Destroy(player);
                player.transform.localPosition += 2 * rightBorder;
            }
            else if (viewPosPlayer.x > 1.03)
            {
                // Debug.Log("out");
                // Destroy(player);
                player.transform.localPosition += 2 * leftBorder;
            }
        }

        foreach (GameObject enemy in Enemies)
        {
            if (enemy != null)
            {
                enemyPos = enemy.transform.position;
                viewPosEnemy = cameraM.WorldToViewportPoint(enemyPos);
                if (viewPosEnemy.x < -0.03)
                {
                    enemy.transform.localPosition += 2 * rightBorder;
                }
                else if (viewPosEnemy.x > 1.03)
                {
                    // Debug.Log("Enemy out");
                    enemy.transform.localPosition += 2 * leftBorder;
                }
            }
        }
    }
}
