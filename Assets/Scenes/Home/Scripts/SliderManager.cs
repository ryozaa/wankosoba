using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderManager : MonoBehaviour
{
    public List<Slider> sliders;
    public MenuManager menuManager;

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
        UnSelectAll();
        menuManager.Close();
    }

    public void UnSelectAll()
    {
        foreach (Slider slider in sliders) {
            slider.UnSelect();
        }
    }

    public void OnSelect()
    {
        menuManager.Close();
    }
}
