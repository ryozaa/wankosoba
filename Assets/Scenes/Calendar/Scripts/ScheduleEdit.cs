using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScheduleEdit : MonoBehaviour
{
    public Text Year;
    public Text Date;
    public InputField titleField;
    public InputField descField;
    public IconManager iconManager;
    public ToggleButton remind;
    public TimePicker timePicker;
    public Button backButton;
    public Button updateButton;

    void Start()
    {
        int id = ScheduleDetail.ScheduleId;
        if (id == 0) return;
        Year.text = Calendar.SelectedDate.ToString("yyyy年");
        Date.text = Calendar.SelectedDate.ToString("M月d日");

        var result = ScheduleTable.FindById(id);
        if (result.Rows.Count == 0) return;

        var data = result.Rows[0];
        titleField.text = (string)data["title"];
        descField.text = (string)data["detail"];

        backButton.onClick.AddListener(() => {
          SceneManager.LoadScene("ScheduleDetail");
        });
        updateButton.onClick.AddListener(UpdateSchedule);
    }

    void UpdateSchedule()
    {
        string date = Calendar.SelectedDate.ToString("yyyy-MM-dd");
        string title = titleField.text;
        string detail = descField.text;
        int icon = iconManager.selectedId;
        int remind = 0;
        string time = timePicker.HourText.text + ":" + timePicker.MinuteText.text;
        ScheduleTable.Update(ScheduleDetail.ScheduleId, date, title, detail, icon, remind, time);

        SceneManager.LoadScene("ScheduleDetail");
    }
}
