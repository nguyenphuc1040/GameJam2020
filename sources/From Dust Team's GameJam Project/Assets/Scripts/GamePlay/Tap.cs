using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Tap : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "LeftBtnJump")
        {
            PlayerCtrl.ins.PressJumpLeft();
        }
        else 
        {
            PlayerCtrl.ins.PressJumpRight();
        }
    }
}
