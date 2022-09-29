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
        return Instantiate(balloon) as GameObject;
    }

    public void ReturnInstance(GameObject gameObjectToPool){
        instanceQueuePool.Enqueue(gameObjectToPool);
        gameObjectToPool.SetActive(false);
        gameObjectToPool.transform.SetParent(gameObject.transform);
    }
    
}
