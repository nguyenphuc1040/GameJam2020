using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Line : MonoBehaviour
{
    Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
        StartCoroutine(_Line());
    }
    string[] linex = {
        "line",
        "line.",
        "line..",
        "line..."
    };
    IEnumerator _Line(){
        for (int i=0; i<4; i++){
            yield return new WaitForSeconds(1f);
            txt.text = linex[i];
        }
        StartCoroutine(_Line());
    }
}
