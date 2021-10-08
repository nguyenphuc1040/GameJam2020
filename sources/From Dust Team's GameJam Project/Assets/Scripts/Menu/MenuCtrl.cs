using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCtrl : MonoBehaviour
{
    public GameObject Bug;
    void Start()
    {
        Instantiate(Bug,new Vector2(Random.Range(-1f,1f),Random.Range(-3f,3f)),Quaternion.identity);
        Instantiate(Bug,new Vector2(Random.Range(-1f,1f),Random.Range(-3f,3f)),Quaternion.identity);
    }
    void Update()
    {
        
    }

    public void _PressPlay(){
        SceneManager.LoadScene("GamePlay");
    }
    public void _PressExit(){
        Application.Quit();
    }
}
