using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;
    public SliderManager sliderManager;
    private Image image;
    public Animator animator;
    private bool isOpen = false;

    void Start()
    {
        image = GetComponent<Image>();

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

    private void Open()
    {
        isOpen = true;
        animator.Play("MenuIn");
        image.sprite = closeSprite;
        sliderManager.UnSelectAll();
    }

    public void Close()
    {
        isOpen = false;
        animator.Play("MenuOut");
        image.sprite = openSprite;
    }
}
