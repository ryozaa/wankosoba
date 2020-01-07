using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmList : MonoBehaviour
{
    public GameObject AlarmPanel;
    public GameObject AddPanel;

    void Start()
    {
        var result = AlarmTable.FindAll();
        foreach (var data in result.Rows) {
            var panel = Instantiate(AlarmPanel);
            panel.GetComponent<AlarmPanel>().Init((int)data["alarm_id"], (string)data["time"], (int)data["status"] == 1);
            panel.transform.SetParent(transform);
        }
        AddPanel.transform.SetAsLastSibling();
    }
}
