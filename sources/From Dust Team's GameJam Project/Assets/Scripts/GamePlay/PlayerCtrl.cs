using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl ins;

    public float Fx, Fy;
    private Rigidbody2D mybody;
    private Animator anim;
    private bool JumpLeft, JumpRight, BeforeR;
    public AudioSource audioSource;
    public AudioClip Jump_AudioClip, Died_AudioClip;
 
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ins = this;
    }
    private void Update() {
        if (GamePlayCtrl.ins.isTimeScale){
            mybody.bodyType = RigidbodyType2D.Static;
        } else {
            mybody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    public GameObject JumpEffect;
    public void PressJumpLeft()
    {
        _instantiateJumpEffect();
        _PlayOneShotAudio(Jump_AudioClip);
        BeforeR = false;
        mybody.Sleep();
        mybody.velocity = new Vector2(mybody.velocity.x - Fx, Fy);
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward * (Fx * 10));
    }

    public void PressJumpRight()
    {
        _instantiateJumpEffect();
        _PlayOneShotAudio(Jump_AudioClip);
        BeforeR = true;
        mybody.Sleep();
        mybody.velocity = new Vector2(mybody.velocity.x + Fx, Fy);
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.back * (Fx * 10));
    }
    void _instantiateJumpEffect(){
        GameObject tmp = Instantiate(JumpEffect,new Vector2(transform.position.x-0.05f,transform.position.y-0.25f),Quaternion.identity);
        Destroy(tmp,0.2f);
    }
    void _PlayOneShotAudio(AudioClip x){
        audioSource.PlayOneShot(x);
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadline")
        {
            _PlayOneShotAudio(Died_AudioClip);
            anim.SetTrigger("Died");
            StartCoroutine(DiedTime(target.gameObject.GetComponent<Enemy>().EnemyID));

        }
        if (target.gameObject.tag == "Redline")
        {
            _PlayOneShotAudio(Died_AudioClip);
            anim.SetTrigger("Died");
            StartCoroutine(DiedTime(target.gameObject.GetComponent<Redline>().EnemyID));

        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Redline")
        {
            _PlayOneShotAudio(Died_AudioClip);
            anim.SetTrigger("Died");
            StartCoroutine(DiedTime(target.gameObject.GetComponent<Redline>().EnemyID));
        }
    }
    IEnumerator DiedTime(int id)
    {
        yield return new WaitForSeconds(0.2f);
        
        GamePlayCtrl.ins._SetActivePanelGameOver(true,id);
    }
}
