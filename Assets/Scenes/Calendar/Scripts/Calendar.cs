using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public Button prevButton;
    public Button nextButton;
    public Text yearText;
    public Text monthText;

    public GameObject panel;
    private List<CalendarPanel> panelList = new List<CalendarPanel>();
    private DateTime current;

    void Start()
    {
        int panelWidth = 150;
        int panelHeight = 200;

        // パネルを配置
        Vector2 parentPos = transform.position;
        for (int y = 0; y < 6; y++) {
            for (int x = 0; x < 7; x++) {
                Vector2 pos = new Vector2(parentPos.x + panelWidth * x, parentPos.y - panelHeight * y);
                GameObject clonePanel = (GameObject)Instantiate(panel, pos, Quaternion.identity);

                Text panelText = clonePanel.transform.Find("Text").GetComponent<Text>();
                // 日曜日のとき
                if (x == 0) {
                    panelText.color = new Color(1f, 0.195f, 0.195f);
                }
                // 土曜日のとき
                else if (x == 6) {
                    panelText.color = new Color(0.195f, 0.195f, 1f);
                }

                panelList.Add(clonePanel.GetComponent<CalendarPanel>());
                clonePanel.transform.SetParent(transform);
            }
        }

        // カレンダーをセット
        current = DateTime.Now;
        SetCalendar();

        prevButton.onClick.AddListener(Prev);
        nextButton.onClick.AddListener(Next);
  }

    private void SetCalendar()
    {
        yearText.text = current.Year + "年";
        monthText.text = current.Month + "月";

        var prev = current.AddMonths(-1);
        var next = current.AddMonths(1);

        int dayOffset = (int) new DateTime(current.Year, current.Month, 1).DayOfWeek - 1;
        int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

        int day = 1;
        int prevMonthDay = DateTime.DaysInMonth(prev.Year, prev.Month) - dayOffset;
        int nextMonthDay = 1;

        for (int i = 0; i < 42; i++) {
            var panel = panelList[i];

            float alpha = 1f;
            // 今月の1日より前
            if (i <= dayOffset) {
                panel.Datetime = new DateTime(prev.Year, prev.Month, prevMonthDay);
                panel.Text.text = prevMonthDay.ToString();
                alpha = 0.3f;
                prevMonthDay ++;
            }
            // 今月の最終日より後ろ
            else if (day > daysInMonth) {
                panel.Datetime = new DateTime(next.Year, next.Month, nextMonthDay);
                panel.Text.text = nextMonthDay.ToString();
                alpha = 0.3f;
                nextMonthDay ++;
            }
            // 今月の日付
            else {
                panel.Datetime = new DateTime(current.Year, current.Month, day);
                panel.Text.text = day.ToString();
                day ++;
            }

            var col = panel.Text.color;
            panel.Text.color = new Color(col.r, col.g, col.b, alpha);
        }
    }

    private void Prev()
    {
        current = current.AddMonths(-1);
        SetCalendar();
    }

    private void Next()
    {
        current = current.AddMonths(1);
        SetCalendar();
    }
}
