﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schedule : MonoBehaviour
{
    public GameObject SchedulePanel;
    public GameObject AddPanel;
    public Text YearText;
    public Text MonthText;
    public Button PrevButton;
    public Button NextButton;
    private DateTime current;
    private List<GameObject> scheduleList = new List<GameObject>();

    public void Start()
    {
        current = Calendar.SelectedDate;
        PrevButton.onClick.AddListener(Prev);
        NextButton.onClick.AddListener(Next);
        LoadSchedule();
    }

    public void LoadSchedule()
    {
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

        clonePanel.transform.Find("Text").GetComponent<Text>().text = (string) data["title"];
        clonePanel.transform.SetParent(transform);

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