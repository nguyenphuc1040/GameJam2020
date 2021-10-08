using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anten : MonoBehaviour
{
    public GameObject father;
    int isCollider;
    private void OnTriggerEnter2D(Collider2D other) {
        isCollider++;
        if(isCollider>0) father.SendMessage("_Iscollider",true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        isCollider--;
        if (isCollider<=0) father.SendMessage("_Iscollider",false);
    }
}
