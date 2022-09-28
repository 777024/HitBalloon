using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    GameObject[] enemies = null;
    GameObject[] feet = null;
    ArrayList feetTrigger = new ArrayList(5);
    GameObject[] head = null;
    ArrayList headTrigger = new ArrayList(5);
    GameObject[] balloons = null;
    Vector3 enemyPos;
    Vector3 viewPosEnemy;


    GameObject player;
    GameObject playersHead;
    GameObject playersFeet;
    Vector3 playerPos;
    Vector3 viewPosPlayer;



    Camera cameraM;
    //camera borders
    Vector3 leftBorder;
    Vector3 rightBorder;
    Scene scene;
    BalloonPool balloonPool;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cameraM = Camera.main;
        leftBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(-0.03f, 0)).x, 0, 0);
        rightBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(1.03f, 0)).x, 0, 0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        feet = GameObject.FindGameObjectsWithTag("Feet");
        head = GameObject.FindGameObjectsWithTag("Head");
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        scene = gameObject.AddComponent<Scene>();
        balloonPool = GameObject.Find("BalloonPool").GetComponent<BalloonPool>();

        foreach (var item in feet)
        {
            feetTrigger.Add(item.GetComponent<BoxCollider2D>());
        }
        foreach (var item in head)
        {
            headTrigger.Add(item.GetComponent<BoxCollider2D>());
        }

    }

    void PlayerViewPosDetect()
    {
        if (player != null)
        {
            playerPos = player.transform.position;
            viewPosPlayer = cameraM.WorldToViewportPoint(playerPos);
            if (viewPosPlayer.x < -0.03)
            {
                player.transform.localPosition += 2 * rightBorder;
            }
            else if (viewPosPlayer.x > 1.03)
            {
                player.transform.localPosition += 2 * leftBorder;
            }
        }
    }
    void EnemyViewPosDetect()
    {
        foreach (GameObject enemy in enemies)
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
                    enemy.transform.localPosition += 2 * leftBorder;
                }
            }
        }
    }


    void FeetTouchBalloonOrHeadDetect()
    {
        foreach (var feet in feetTrigger)
        {
            foreach (var head in headTrigger)
            {
                if ((BoxCollider2D)feet != null && (BoxCollider2D)head != null)
                {
                    if (((BoxCollider2D)feet).IsTouching((BoxCollider2D)head))
                    {
                        // Debug.Log("feet on head");
                        // ((BoxCollider2D)head).GetComponentInParent<Balloon>().balloonNumer -= 1;
                        // Destroy(((BoxCollider2D)head).transform.parent.gameObject);
                        ((BoxCollider2D)head).transform.parent.gameObject.SetActive(false);
                    }
                }
            }

            foreach (var balloon in balloons)
            {
                if ((BoxCollider2D)feet != null && balloon != null)
                {
                    if (((BoxCollider2D)feet).IsTouching(balloon.GetComponent<CircleCollider2D>()))
                    {
                        balloon.GetComponentInParent<Balloon>().balloonNumer -= 1;
                        // Debug.Log("touch balloon");
                    }
                }
            }
        }
    }

    void PlayerDie()
    {
        if (player.activeSelf == false)
        {
            Time.timeScale = 0;
        }
    }

    void LevelClear()
    {
        if (enemies.Length == 5)
        {
            if (enemies[0].activeSelf == false &&
            enemies[1].activeSelf == false &&
            enemies[2].activeSelf == false &&
            enemies[3].activeSelf == false &&
            enemies[4].activeSelf == false)
            {
                scene.Scene2();
            }
        }
    }

    void addBalloonsToScene()
    {//get a balloon from pool
     //balloon goes up
     //if player touch balloon
     //send it back to the pool
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerViewPosDetect();
        EnemyViewPosDetect();
        FeetTouchBalloonOrHeadDetect();

        PlayerDie();
        LevelClear();
    }

}
