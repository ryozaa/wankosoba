using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScheduleAddPanel : MonoBehaviour, IPointerClickHandler
{
    public Schedule Schedule;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("ScheduleAdd");
    }
}
