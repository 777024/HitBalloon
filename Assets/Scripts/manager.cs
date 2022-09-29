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
    private List<GameObject> balloonList = new List<GameObject>();
    int balloonCounter = 0;
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
        balloonPool = gameObject.GetComponent<BalloonPool>();
        GetBalloons();
        balloonCounter = balloonList.Count - 1;
        foreach (var item in feet)
        {
            feetTrigger.Add(item.GetComponent<BoxCollider2D>());
        }
        foreach (var item in head)
        {
            headTrigger.Add(item.GetComponent<BoxCollider2D>());
        }

        InvokeRepeating("AddBalloonsToScene", 2, 4);
        // InvokeRepeating("DetectBalloonsInScene", 0, 10);
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

    void AddBalloonsToScene()
    {//get a balloon from pool
     //balloon goes up
     // x of four pipes -3.805762  1.19 5.81 11.25  
        if (balloonCounter > 0)
        {
            var balloon = balloonList[balloonCounter];
            var randomNumber = Random.value;
            if (randomNumber < 0.25)
            {
                BalloonChangePosition(1, balloon);
                --balloonCounter;
            }
            else if (randomNumber < 0.5)
            {
                BalloonChangePosition(2, balloon);
                --balloonCounter;
            }
            else if (randomNumber < 0.75)
            {
                BalloonChangePosition(3, balloon);
                --balloonCounter;
            }
            else if (randomNumber < 1)
            {
                BalloonChangePosition(4, balloon);
                --balloonCounter;
            }
        }


    }

    void BalloonChangePosition(int pipe, GameObject balloon)
    {
        if (pipe == 1)
        {
            balloon.transform.position = Vector3.right * -7.0999999f + Vector3.up * -3.25529f;
        }
        if (pipe == 2)
        {
            balloon.transform.position = Vector3.right * -2.10423779f + Vector3.up * -3.805297f;
        }
        if (pipe == 3)
        {
            balloon.transform.position = Vector3.right * 2.51576209f + Vector3.up * -3.025297f;
        }
        if (pipe == 4)
        {
            balloon.transform.position = Vector3.right * 7.9557619f + Vector3.up * -3.585297f;
        }
    }
    void DetectBalloonsInScene()
    {

    }

    private void GetBalloons()
    {
        for (int i = 0; i < 20; i++)
        {
            var obj = balloonPool.GetInstance();
            obj.transform.SetParent(gameObject.transform);
            balloonList.Add(obj);
        }
    }
    private void ReturnBalloons()
    {
        for (int i = 0; i < 20; i++)
        {
            balloonPool.ReturnInstance(balloonList[i]);
        }
        balloonList.Clear();
    }
    // Update is called once per frame
    void Update()
    {

        PlayerViewPosDetect();
        EnemyViewPosDetect();
        FeetTouchBalloonOrHeadDetect();

        PlayerDie();
        LevelClear();
        
        // DetectBalloonsInScene();
    }

}
