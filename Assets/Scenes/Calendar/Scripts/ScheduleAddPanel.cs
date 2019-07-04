using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScheduleAddPanel : MonoBehaviour
{
    public Schedule Schedule;

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
        Schedule.Add();
    }
}
