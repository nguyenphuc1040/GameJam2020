using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    public bool rand;
    private float dir;
    private void Start() {
        if (rand) {
            dir = Random.Range(0,2);
            if (dir==0) dir=-1;
        } else dir = 1;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward*speed*dir*Time.deltaTime);
    }
}
