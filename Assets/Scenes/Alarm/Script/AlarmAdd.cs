using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlarmAdd : MonoBehaviour
{
    public TimePicker TimePicker;
    public List<Toggle> CheckboxList;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public Button SnoozeToggle;
    public Button BackButton;
    public Button AddButton;
    private bool isSnooze = true;

    void Start()
    {
        SnoozeToggle.onClick.AddListener(toggle);
        AddButton.onClick.AddListener(add);
        BackButton.onClick.AddListener(
            () => SceneManager.LoadScene("AlarmList")
        );
    }

    private void toggle()
    {
        isSnooze = !isSnooze;
        Sprite sprite = null;
        if (isSnooze) {
            sprite = OnSprite;
        } else {
            sprite = OffSprite;
        }
        SnoozeToggle.targetGraphic.GetComponent<Image>().sprite = sprite;
    }

    private void add()
    {
        string time = TimePicker.ToString();
        int snooze = (isSnooze) ? 1 : 0;
        int mon = (CheckboxList[0].isOn) ? 1 : 0;
        int tue = (CheckboxList[1].isOn) ? 1 : 0;
        int wed = (CheckboxList[2].isOn) ? 1 : 0;
        int thu = (CheckboxList[3].isOn) ? 1 : 0;
        int fri = (CheckboxList[4].isOn) ? 1 : 0;
        int sat = (CheckboxList[5].isOn) ? 1 : 0;
        int sun = (CheckboxList[6].isOn) ? 1 : 0;

        AlarmTable.Insert(time, snooze, sun, mon, tue, wed, thu, fri, sat);
        SceneManager.LoadScene("AlarmList");
    }
}
