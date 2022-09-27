using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishKill : MonoBehaviour
{
    float timer = 2f;
    GameObject intoWater;
    public GameObject fish;
    Vector3 place;
    Vector3 init = new Vector3(-17.5687733f,-5.1876297f,0);
    // Start is called before the first frame update
    void Start()
    {
        fish = GameObject.Instantiate(fish);
        fish.transform.position = init;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        timer = 2;
        // Debug.Log("in water");
        intoWater = other.gameObject;
        place = intoWater.transform.position;
        // Debug.Log(place);
        // fish = GameObject.Instantiate(fish);
        // Destroy(intoWater);
        intoWater.SetActive(false);
        fish.transform.position = place;
    }
    // Update is called once per frame
    void Update()
    {   
        if (fish.transform.position != init)
        {
            timer -= Time.deltaTime;
            if(timer < 0){
                fish.transform.position = init;
            }
        }

    }
}
