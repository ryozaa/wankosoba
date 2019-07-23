using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScheduleAddPanel : MonoBehaviour, IPointerClickHandler
{
    public Schedule Schedule;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("クリックされたよ。");
    }
}
