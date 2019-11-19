using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SchedulePanel : MonoBehaviour, IPointerClickHandler
{
    public List<Sprite> IconSpriteList;
    public GameObject Icon;
    public Text Text;
    private int id;

    public void Init(int id, int icon, string text) {
        Icon.GetComponent<Image>().sprite = IconSpriteList[icon];
        Text.text = text;
        this.id = id;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ScheduleDetail.ScheduleId = id;
        SceneManager.LoadScene("ScheduleDetail");
    }
}
