using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPool : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon;

    private Queue<GameObject> instanceQueuePool = new Queue<GameObject>();

    public GameObject GetInstance(){
        if (instanceQueuePool.Count > 0)
        {
            GameObject reusableInstance = instanceQueuePool.Dequeue();
            reusableInstance.SetActive(true);
            return reusableInstance;
        }
        return Instantiate(balloon);
    }

    public void SendInstanceToPool(GameObject gameObjectToPool){
        instanceQueuePool.Enqueue(gameObjectToPool);
        gameObjectToPool.SetActive(false);
        gameObjectToPool.transform.SetParent(gameObject.transform);
    }
    
    private void Start() {
        GameObject balloon = GameObject.Find("ScoreBalloon");
        SendInstanceToPool(balloon);
    }
}
