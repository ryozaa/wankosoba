using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePicker : MonoBehaviour
{
    public Button HourUp;
    public Button HourDown;
    public Button MinuteUp;
    public Button MinuteDown;

    public Text HourText;
    public Text MinuteText;

    public int hour = 12;
    public int minute = 0;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        HourUp.onClick.AddListener(() => { addHour(1); });
        HourDown.onClick.AddListener(() => { addHour(-1); });
        MinuteUp.onClick.AddListener(() => { addMinute(5); });
        MinuteDown.onClick.AddListener(() => { addMinute(-5); });
        setActive(false);
        display();
    }

    private void addHour(int value)
    {
        hour += value;
        if (23 < hour) {
            hour = 0;
        }
        else if (hour < 1) {
            hour = 23;
        }
        display();
    }

    private void addMinute(int value)
    {
        minute += value;
        if (55 < minute) {
            minute = 0;
        }
        else if (minute < 0) {
            minute = 55;
        }
        display();
    }

    private void display()
    {
        HourText.text = hour.ToString();
        MinuteText.text = String.Format("{0:00}", minute);
    }

    public void setActive(bool flag)
    {
        if (flag) {
            canvasGroup.alpha = 1f;
        }
        else {
            canvasGroup.alpha = 0.5f;
        }
        canvasGroup.interactable = flag;
    }
}
