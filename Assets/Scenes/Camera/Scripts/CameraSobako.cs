using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraSobako : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data){}

    public void OnDrag(PointerEventData data)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.dragging) return;
        Debug.Log("クリックされたよ");
    }
}
