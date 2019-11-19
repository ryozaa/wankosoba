using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScheduleDetail : MonoBehaviour
{
    public static int ScheduleId;
    public Text Year;
    public Text Date;
    public Text Title;
    public Text Detail;
    public Text Remind;

    public Button BackButton;
    public Button EditButton;
    public Button DeleteButton;

    void Start()
    {
        if (ScheduleId == 0) return;
        var result = ScheduleTable.FindById(ScheduleId);
        if (result.Rows.Count == 0) return;
        var data = result.Rows[0];
        
        var date = DateTime.Parse((string)data["date"]);
        var icon = (int)data["icon"];

        Year.text = date.ToString("yyyy年");
        Date.text = date.ToString("M月d日");
        Title.text = (string)data["title"];
        Detail.text = (string)data["detail"];
        Remind.text = (string)data["time"];

        BackButton.onClick.AddListener(() => {
            SceneManager.LoadScene("ScheduleList");
        });
    }
}
