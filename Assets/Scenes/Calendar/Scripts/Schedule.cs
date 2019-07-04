using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schedule : MonoBehaviour
{
    public GameObject SchedulePanel;
    public GameObject AddPanel;
    private List<SchedulePanel> scheduleList = new List<SchedulePanel>();

    public void Start()
    {
    }

    public void Add()
    {
        var clonePanel = (GameObject)Instantiate(SchedulePanel, new Vector2(), Quaternion.identity);
        clonePanel.transform.SetParent(transform);

        AddPanel.transform.SetAsLastSibling();
    }
}
