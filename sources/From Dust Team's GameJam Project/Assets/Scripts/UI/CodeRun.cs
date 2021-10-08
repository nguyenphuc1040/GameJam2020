using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeRun : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,55f);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y-1*Time.deltaTime);
    }
}
