using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SchedulePanel : MonoBehaviour, IPointerClickHandler
{
    public Image Icon;
    public Text Text;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("クリックされたよ。");
    }
}
