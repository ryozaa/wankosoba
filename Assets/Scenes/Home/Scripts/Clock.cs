using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text date;
    public Text time;
    public Text week;
    private float span = 0.5f;

    void Start ()
    {
        ClockUpdate();
        InvokeRepeating("ClockUpdate", span, span);
    }

    void ClockUpdate ()
    {
        DateTime dateTime = DateTime.Now;
        date.text = dateTime.ToString("MM / dd");
        if (dateTime.Millisecond < 500) {
            time.text = dateTime.ToString("HH : mm");
        } else {
            time.text = dateTime.ToString("HH   mm");
        }
        var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        week.text = dateTime.ToString("ddd", culture);
    }
}
