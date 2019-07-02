using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // 非表示にする
        gameObject.SetActive(false);

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // クリックされたときにOnClickを呼び出す
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnClick);

        trigger.triggers.Add(entry);
    }

    private void OnClick(BaseEventData eventData)
    {
    }

    public void Open()
    {
        gameObject.SetActive(true);
        animator.Play(this.name + "In");
    }

    public void Close()
    {
       animator.Play(this.name + "Out");
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
