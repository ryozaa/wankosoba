using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlarmEdit : MonoBehaviour
{
    public static int id;
    public TimePicker TimePicker;
    public List<Toggle> CheckboxList;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public Button SnoozeToggle;
    public Button BackButton;
    public Button UpdateButton;
    public Button DeleteButton;
    private bool isSnooze = true;
    
    void Start()
    {
        var result = AlarmTable.FindById(id);
        if (result.Rows.Count == 0) {
            SceneManager.LoadScene("AlarmList");
            return;
        }

        var data = result.Rows[0];
        CheckboxList[0].isOn = (int) data["repeat_mon"] == 1;
        CheckboxList[1].isOn = (int) data["repeat_tue"] == 1;
        CheckboxList[2].isOn = (int) data["repeat_wed"] == 1;
        CheckboxList[3].isOn = (int) data["repeat_thu"] == 1;
        CheckboxList[4].isOn = (int) data["repeat_fri"] == 1;
        CheckboxList[5].isOn = (int) data["repeat_sat"] == 1;
        CheckboxList[6].isOn = (int) data["repeat_sun"] == 1;
        
        isSnooze = (int) data["snooze"] == 1;

        var time = ((string) data["time"]).Split(':');
        TimePicker.hour = int.Parse(time[0]);
        TimePicker.minute = int.Parse(time[1]);
        TimePicker.display();

        SnoozeToggle.onClick.AddListener(toggle);
        UpdateButton.onClick.AddListener(update);
        DeleteButton.onClick.AddListener(delete);

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
        }
        else {
            sprite = OffSprite;
        }
        SnoozeToggle.targetGraphic.GetComponent<Image>().sprite = sprite;
    }

    private void update()
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

        AlarmTable.Update(id, time, snooze, sun, mon, tue, wed, thu, fri, sat);
        SceneManager.LoadScene("AlarmList");
    }

    private void delete()
    {
        AlarmTable.DeleteById(id);
        SceneManager.LoadScene("AlarmList");
    }
}
