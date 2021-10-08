using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCtrl : MonoBehaviour
{
    public static ManagerCtrl ins;
    private const string bestScore = "best-score";
    void Awake(){
        _makeins();
        _IsFirstTime();
    }
    void _makeins(){
        if (ins!=null){
            Destroy(gameObject);
        } else {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void _IsFirstTime(){
        if (!PlayerPrefs.HasKey("IsFirstTime")){
            PlayerPrefs.SetInt("IsFirstTime",0);
            PlayerPrefs.SetInt(bestScore,0);
        }
    }

    public void _SetBestScore(int x){
        PlayerPrefs.SetInt(bestScore,x);
    }
    public int _GetBestScore(){
        return PlayerPrefs.GetInt(bestScore);
    }
}
