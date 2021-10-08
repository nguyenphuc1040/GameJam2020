using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayCtrl : MonoBehaviour
{
    int Score;
    public Text ScoreTxt, OhnoTxt;
    public Text ResultScoreTxt, BestScoreTxt;
    public static GamePlayCtrl ins;
    public GameObject GameOverPanel,TapTapPanel;
    public bool isTimeScale;
    void Awake(){
        ins = this;
    }
    private void Start() {
        Score = 0;
        ScoreTxt.text = Score+"";
        isTimeScale = true;
        EnemyCtrl.ins._SetScaleTime(isTimeScale);
    }

    string[] SleepStOver = {
        "Oh Friend, Why fall asleep this time >_<",
        "Redbull ! Redbull ! ^_^",
        "Coffee ! Coffee !",
        "Don't give up ! just try again",
    };
    string[] BugStOver = {
        "If debugging is the process of eliminating the bug, the code is the process of creating the bug",
        "Have bugs ! Have bugs",
        "Debug is twice as difficult as code. If you write excessively smart code, you won't be smart enough to debug it"
    };
    string[] ErrorStOver ={
        "The code is too horrible to be tested",
        "I think I have to reset the server",
    };
    string[] Redline = {
        "What one programmer can do in one hour, two programmers can do in two hours",
        "HOPE NOT :((",
        "Come on ! Come on !",
        "Don't give up ! just try again",
        "Every great developer you know got there by solving problems they were unqualified to solve until they actually did it",

    };

    public void _SetActivePanelGameOver(bool x, int id){
        GameOverPanel.SetActive(x);
        isTimeScale = true;
        EnemyCtrl.ins._SetScaleTime(isTimeScale);
        ResultScoreTxt.text = Score+"";
        if (ManagerCtrl.ins._GetBestScore()<Score) ManagerCtrl.ins._SetBestScore(Score);
        BestScoreTxt.text = ManagerCtrl.ins._GetBestScore()+"";
        switch (id){
            case 0: OhnoTxt.text = BugStOver[Random.Range(0,BugStOver.Length)];
                break;
            case 1: OhnoTxt.text = ErrorStOver[Random.Range(0,ErrorStOver.Length)];
                break;
            case 2: OhnoTxt.text = SleepStOver[Random.Range(0,SleepStOver.Length)];
                break;
            default:
                    OhnoTxt.text = Redline[Random.Range(0,Redline.Length)];
                break;
        }
    }

    public void _PressMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void _PressAgain(){
        SceneManager.LoadScene("GamePlay");
    }
    void _SetTimeScl(float t){
        Time.timeScale = t;

    }
    public void _PressTapTap(){
        TapTapPanel.SetActive(false);
        isTimeScale = false;
        EnemyCtrl.ins._SetScaleTime(isTimeScale);
    }
    public AudioSource audio;
    public AudioClip getcoinsound;
    public void _AddScore(){
        Score++;
        ScoreTxt.text = Score+"";
        audio.PlayOneShot(getcoinsound);
    }

}
