using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMove : MonoBehaviour
{
    public bool isCollider;
    int direct;
    void Start()
    {
        direct = 1;
    }

    void Update()
    {
        transform.Translate(Vector3.up*0.7f*Time.deltaTime);
        if (isCollider){
            transform.Rotate(Vector3.forward*5*direct);
        }
    }

    void _Iscollider(bool x){
        isCollider = x;
        direct = Random.Range(0,2);
        if (direct==0) direct = -1;
    }
}
