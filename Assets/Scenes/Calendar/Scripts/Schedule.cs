using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Schedule : MonoBehaviour
{
    public GameObject SchedulePanel;
    public GameObject AddPanel;
    public Text YearText;
    public Text MonthText;
    public Button PrevButton;
    public Button NextButton;
    public Button BackButton;
    private DateTime current;
    private List<GameObject> scheduleList = new List<GameObject>();

    public void Start()
    {
        current = Calendar.SelectedDate;
        PrevButton.onClick.AddListener(Prev);
        NextButton.onClick.AddListener(Next);
        BackButton.onClick.AddListener(() => SceneManager.LoadScene("Calendar"));
        LoadSchedule();
    }

    public void LoadSchedule()
    {
        Calendar.SelectedDate = current;
        YearText.text = current.ToString("yyyy年");
        MonthText.text = current.ToString("M月d日");

        foreach (var schedule in scheduleList) {
            Destroy(schedule);
        }

        var result = ScheduleTable.FindByDate(current.ToString("yyyy-MM-dd"));
        foreach (var data in result.Rows) {
            Add(data);
        }
    }

    public void Add(DataRow data)
    {
        var clonePanel = (GameObject) Instantiate(SchedulePanel, new Vector2(), Quaternion.identity);

        clonePanel.transform.SetParent(transform, false);
        clonePanel.GetComponent<SchedulePanel>().Init((int)data["schedule_id"], (int)data["icon"], (string)data["title"]);

        scheduleList.Add(clonePanel);

        AddPanel.transform.SetAsLastSibling();
    }

    public void Prev()
    {
        current = current.AddDays(-1);
        LoadSchedule();
    }

    public void Next()
    {
        current = current.AddDays(1);
        LoadSchedule();
    }
}
