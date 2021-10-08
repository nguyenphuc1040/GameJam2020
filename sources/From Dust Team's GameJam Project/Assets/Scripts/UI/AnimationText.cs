using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationText : MonoBehaviour
{
    public string species;
    SpriteRenderer renderer;
    Image image;
    void Start()
    {

        image = GetComponent<Image>();
        renderer = GetComponent<SpriteRenderer>();
        if (species=="zoom") StartCoroutine(_TimeLineZoom());
            else if (species=="nhun") StartCoroutine(_TimeLineNhun());
                else if(species=="opacity") StartCoroutine(_TimeLineOpacity());
    }
    IEnumerator _TimeLineZoom(){
        yield return new WaitForSeconds(Random.Range(1f,2f));
        for (int i=0; i<3; i++) {
            _ChangeLocalScale(0.05f);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i=0; i<3; i++) {
            _ChangeLocalScale(-0.05f);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(_TimeLineZoom());
    }
    void _ChangeLocalScale(float size){
        transform.localScale = new Vector2(transform.localScale.x+size, transform.localScale.y+size);
    }
    IEnumerator _TimeLineNhun(){
        yield return new WaitForSeconds(Random.Range(1f,2f));
        for (int i=0; i<3; i++) {
            _ChangePosition(0.05f);
            yield return new WaitForSeconds(0.1f);
        }
        for (int i=0; i<3; i++) {
            _ChangePosition(-0.05f);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(_TimeLineNhun());
    }
    void _ChangePosition(float pos){
        transform.position = new Vector2(transform.position.x,transform.position.y+pos);
    }

    IEnumerator _TimeLineOpacity(){
        yield return new WaitForSeconds(Random.Range(1f,2f));
        for (int i=255; i>=0; i=i-15){
            yield return new WaitForSeconds(0.03f);
            if (renderer){
                Color32 tmp =  renderer.color;
                renderer.color = new Color32(tmp.r,tmp.g,tmp.b,(byte)i);
            } else {
                Color32 tmp = image.color;
                image.color = new Color32(tmp.r,tmp.g,tmp.b,(byte)i);
            }
            
        }
        for (int i=0; i<=255; i=i+15){
            yield return new WaitForSeconds(0.03f);
            if (renderer){
                Color32 tmp =  renderer.color;
                renderer.color = new Color32(tmp.r,tmp.g,tmp.b,(byte)i);
            } else {
                Color32 tmp = image.color;
                image.color = new Color32(tmp.r,tmp.g,tmp.b,(byte)i);
            }
        }
        StartCoroutine(_TimeLineOpacity());
    }
}
