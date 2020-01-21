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
    public static DateTime SelectedDate;

    public GameObject panel;
    public List<Sprite> iconList;
    private List<CalendarPanel> panelList = new List<CalendarPanel>();
    public static DateTime current = DateTime.Now;

    void Start()
    {
        int panelWidth = 150;
        int panelHeight = 200;

        // パネルを配置
        Vector2 parentPos = transform.position;
        for (int y = 0; y < 6; y++) {
            for (int x = 0; x < 7; x++) {
                Vector2 pos = new Vector2(-450 + panelWidth * x, 450 - panelHeight * y);
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
                clonePanel.transform.SetParent(transform, false);
            }
        }

        // カレンダーをセット
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
                panel.Date = new DateTime(prev.Year, prev.Month, prevMonthDay);
                panel.Text.text = prevMonthDay.ToString();
                alpha = 0.3f;
                prevMonthDay ++;
            }
            // 今月の最終日より後ろ
            else if (day > daysInMonth) {
                panel.Date = new DateTime(next.Year, next.Month, nextMonthDay);
                panel.Text.text = nextMonthDay.ToString();
                alpha = 0.3f;
                nextMonthDay ++;
            }
            // 今月の日付
            else {
                panel.Date = new DateTime(current.Year, current.Month, day);
                panel.Text.text = day.ToString();
                day ++;
            }

            var col = panel.Text.color;
            panel.Text.color = new Color(col.r, col.g, col.b, alpha);
            panel.Image.sprite = null;

            var countPanel = panel.CountPanel;
            countPanel.SetActive(false);

            // DBから予定を取得
            var schedules = ScheduleTable.FindByDate(panel.Date.ToString("yyyy-MM-dd"));
            var count = schedules.Rows.Count;
            if (0 < count) {
                int icon = (int) schedules.Rows[0]["icon"];
                panel.Image.sprite = iconList[icon];
                panel.Image.color = new Color(1f, 1f, 1f, alpha);

                if (1 < count) {
                    countPanel.SetActive(true);
                    var text = countPanel.transform.Find("Text").GetComponent<Text>();
                    text.text = count.ToString();
                    if (9 < count) text.text = "9+";
                }
            }
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
