using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    SceneChange scene;
    BalloonPool balloonPool;
    private List<GameObject> balloonList = new List<GameObject>();
    int balloonCounter = 0;
    // bool changeSceneFlag = false;

    public static Text text;
    public static int score = 0;

    void Awake()
    {
        Application.targetFrameRate = 30;
        player = GameObject.Find("Player");
        cameraM = Camera.main;
        leftBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(-0.03f, 0)).x, 0, 0);
        rightBorder = new Vector3(cameraM.ViewportToWorldPoint(new Vector3(1.03f, 0)).x, 0, 0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        feet = GameObject.FindGameObjectsWithTag("Feet");
        head = GameObject.FindGameObjectsWithTag("Head");
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        scene = gameObject.AddComponent<SceneChange>();
        balloonPool = gameObject.GetComponent<BalloonPool>();
        text = GameObject.Find("Score").GetComponent<Text>();

        foreach (var item in feet)
        {
            feetTrigger.Add(item.GetComponent<BoxCollider2D>());
        }
        foreach (var item in head)
        {
            headTrigger.Add(item.GetComponent<BoxCollider2D>());
        }

        
    }
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "Scene2")
        {
            // Debug.Log("qwewqe");
            GetBalloons();
            balloonCounter = balloonList.Count - 1;
            // changeSceneFlag = true;
            InvokeRepeating("AddBalloonsToScene", 2, 4);
            Invoke("ReturnBalloons" , 90);
            ScoreFlush();
        }
        
    }

    void ScoreFlush(){
        text.text = "Score : " + score;
    }
    void ScorePlus500() {
        score += 500;
        text.text = "Score : " + score;
    }
    void ScorePlus750(){
        score += 750;
        text.text = "Score : " + score;
    }
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
                        ScorePlus750();
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
                        ScorePlus500();
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
        Time.timeScale = 0;
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
