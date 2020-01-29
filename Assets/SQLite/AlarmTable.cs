using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTable
{
    private static string table = "alarm";

    public static void Insert(string time, int snooze,
        int sun, int mon, int tue, int wed, int thu, int fri, int sat)
    {
        var data = new Dictionary<string, string>();
        data.Add("time", $"'{time}'");
        data.Add("status", "1");
        data.Add("snooze", snooze.ToString());
        data.Add("repeat_sun", sun.ToString());
        data.Add("repeat_mon", mon.ToString());
        data.Add("repeat_tue", tue.ToString());
        data.Add("repeat_wed", wed.ToString());
        data.Add("repeat_thu", thu.ToString());
        data.Add("repeat_fri", fri.ToString());
        data.Add("repeat_sat", sat.ToString());

        WankoDB.Insert(table, data);
    }

    public static void Update(int id, string time, int snooze,
        int sun, int mon, int tue, int wed, int thu, int fri, int sat)
    {
        var data = new Dictionary<string, string>();
        data.Add("time", $"'{time}'");
        data.Add("status", "1");
        data.Add("snooze", snooze.ToString());
        data.Add("repeat_sun", sun.ToString());
        data.Add("repeat_mon", mon.ToString());
        data.Add("repeat_tue", tue.ToString());
        data.Add("repeat_wed", wed.ToString());
        data.Add("repeat_thu", thu.ToString());
        data.Add("repeat_fri", fri.ToString());
        data.Add("repeat_sat", sat.ToString());

        WankoDB.Update(table, data, "alarm_id", id.ToString());
    }

    public static DataTable FindAll()
    {
        return WankoDB.FindAll(table);
    }

    public static DataTable FindById(int id)
    {
        return WankoDB.FindBy(table, "alarm_id", id.ToString());
    }

    public static DataTable FindByTime(string time)
    {
        return WankoDB.FindBy(table, "time", $"'{time}'");
    }

    public static void DeleteById(int id)
    {
        WankoDB.DeleteBy(table, "alarm_id", id.ToString());
    }
}
