using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public static EnemyCtrl ins;
    public GameObject Enemy;
    public float timeReborn;
    public bool isTimeScale;
    void Awake(){
        ins = this;
    }
    void Start()
    {
        StartCoroutine(_SpawnEnemy());
    }
    IEnumerator _SpawnEnemy(){
        yield return new WaitForSeconds(0.1f);
        if (!isTimeScale) 
            Instantiate(Enemy,new Vector2(transform.position.x+Random.Range(-1.5f,1.5f),transform.position.y),Quaternion.identity);
        yield return new WaitForSeconds(timeReborn);
        StartCoroutine(_SpawnEnemy());
    }
    public void _SetScaleTime(bool x){
        isTimeScale = x;
    }
}