using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderManager : MonoBehaviour
{
    public List<Slider> sliders;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // クリックされたときにOnClickedを呼び出す
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnClicked);

        trigger.triggers.Add(entry);
    }

    private void OnClicked(BaseEventData eventData)
    {
        UnSelectAll();
    }

    public void UnSelectAll()
    {
        foreach (Slider slider in sliders) {
            slider.UnSelect();
        }
    }
}
