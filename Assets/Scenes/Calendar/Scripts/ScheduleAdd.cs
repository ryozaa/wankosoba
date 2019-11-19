using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScheduleAdd : MonoBehaviour
{
    public Text Year;
    public Text Date;
    public InputField titleField;
    public InputField descField;
    public IconManager iconManager;
    public ToggleButton remind;
    public TimePicker timePicker;
    public Button backButton;
    public Button addButton;

    void Start()
    {
        Year.text = Calendar.SelectedDate.ToString("yyyy年");
        Date.text = Calendar.SelectedDate.ToString("M月d日");

        backButton.onClick.AddListener(() => {
          SceneManager.LoadScene("ScheduleList");
        });
        addButton.onClick.AddListener(Add);
    }

    void Add()
    {
        string date = Calendar.SelectedDate.ToString("yyyy-MM-dd");
        string title = titleField.text;
        string detail = descField.text;
        int icon = iconManager.selectedId;
        int remind = 0;
        string time = timePicker.HourText.text + ":" + timePicker.MinuteText.text;
        ScheduleTable.Insert(date, title, detail, icon, remind, time);

        SceneManager.LoadScene("ScheduleList");
    }
}
