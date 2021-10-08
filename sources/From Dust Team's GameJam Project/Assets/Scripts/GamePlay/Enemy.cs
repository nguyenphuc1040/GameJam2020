using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bomb;
    public float speeddown;
    public int EnemyID;
    public GameObject[] ms = new GameObject[3];
    void Start()
    {
        int a = Random.Range(0,3);
        if (a==0) transform.Rotate(transform.forward*Random.Range(-180f,180f));
        ms[a].SetActive(true);
        EnemyID = a;
    }
    void Update()
    {
        if (GamePlayCtrl.ins.isTimeScale) return;
        transform.position = new Vector2(transform.position.x,transform.position.y-speeddown*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Redline"){
            GamePlayCtrl.ins._AddScore();
            GameObject tmp = Instantiate(bomb,new Vector2(transform.position.x,transform.position.y-0.1f),Quaternion.identity);
            Destroy(tmp,0.4f);
            Destroy(gameObject);
        }
    }
}
