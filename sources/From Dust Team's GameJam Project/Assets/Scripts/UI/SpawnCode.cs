using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCode : MonoBehaviour
{
    public GameObject CodePrefab;
    void Start()
    {
        StartCoroutine(_SpawnCode());
    }

    public Transform CodeSpawnPos;
    IEnumerator _SpawnCode(){
        Instantiate(CodePrefab,CodeSpawnPos.position,CodeSpawnPos.rotation);
        yield return new WaitForSeconds(32.5f);
        StartCoroutine(_SpawnCode());
    }
}
