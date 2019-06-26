using UnityEngine;
using UnityEngine.EventSystems;

public class Slider : MonoBehaviour
{
    public SliderManager sliderManager;
    private Animator animator;
    private bool isSelected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // クリックされたときにOnClickedを呼び出す
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnClicked);

        trigger.triggers.Add(entry);
    }

    private void OnClicked(BaseEventData eventData)
    {
        if (isSelected) return;
        sliderManager.UnSelectAll();
        Select();
    }

    public void Select()
    {
        if (isSelected) return;
        isSelected = true;
        animator.Play("SlideIn");
    }

    public void UnSelect()
    {
        if (!isSelected) return;
        isSelected = false;
        animator.Play("SlideOut");
    }
}
