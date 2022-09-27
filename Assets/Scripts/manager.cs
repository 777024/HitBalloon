using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    GameObject[] enemies = null;
    public GameObject[] feet = null;
    ArrayList feetTrigger = new ArrayList(5);
    public GameObject[] head = null;
    ArrayList headTrigger = new ArrayList(5);
    public GameObject[] balloons = null;
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


        foreach (var item in feet)
        {
            // BoxCollider2D test = item.GetComponent<BoxCollider2D>().IsTouching()
            feetTrigger.Add(item.GetComponent<BoxCollider2D>());
        }
        foreach (var item in head)
        {
            headTrigger.Add(item.GetComponent<BoxCollider2D>());
        }

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
                    // Debug.Log("Enemy out");
                    enemy.transform.localPosition += 2 * leftBorder;
                }
            }
        }

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
                        Destroy(((BoxCollider2D)head).transform.parent.gameObject);
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
}
