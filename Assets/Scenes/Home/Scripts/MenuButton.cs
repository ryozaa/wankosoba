using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public string sceneName;
    private Animator animator;

    void Start()
    {
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
        // 各画面に遷移する
        SceneManager.LoadScene(sceneName);
    }
}
