using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Slider : MonoBehaviour
{
    public SliderManager sliderManager;
    public string sceneName;
    private Animator animator;
    private bool isSelected = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // クリックされたときにOnClickを呼び出す
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(OnClick);

        trigger.triggers.Add(entry);
    }

    private void OnClick(BaseEventData eventData)
    {
        if (isSelected) {
            SceneManager.LoadScene(sceneName);
            return;
        }
        sliderManager.UnSelectAll();
        Select();
    }

    public void Select()
    {
        if (isSelected) return;
        isSelected = true;
        animator.Play("SlideIn");
        sliderManager.OnSelect();
    }

    public void UnSelect()
    {
        if (!isSelected) return;
        isSelected = false;
        animator.Play("SlideOut");
    }
}
