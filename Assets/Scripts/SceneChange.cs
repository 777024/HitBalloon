using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Scene1(){
        SceneManager.LoadScene(0);
        System.GC.Collect();
        Time.timeScale = 1;
    }

    public void Scene2(){
        SceneManager.LoadScene(1);
        System.GC.Collect();
        Time.timeScale = 1;
    }

}
