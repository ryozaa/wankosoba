using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;
    public List<MenuButton> menuButtons;
    public SliderManager sliderManager;
    private bool isOpen = false;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // クリックされたときにOnClickを呼び出す
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnClick);

        trigger.triggers.Add(entry);
    }

    private void OnClick(BaseEventData eventData)
    {
        if (!isOpen) {
            Open();
        } else {
            Close();
        }
    }

    public void Open()
    {
        if (isOpen) return;
        isOpen = true;

        foreach (MenuButton menuButton in menuButtons) {
            menuButton.Open();
        }
        GetComponent<Image>().sprite = closeSprite;
        sliderManager.UnSelectAll();
    }

    public void Close()
    {
        if (!isOpen) return;
        isOpen = false;

        foreach (MenuButton menuButton in menuButtons) {
            menuButton.Close();
        }
        GetComponent<Image>().sprite = openSprite;
    }
}
