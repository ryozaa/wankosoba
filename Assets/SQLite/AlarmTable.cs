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
        data.Add("repeat_mon", sun.ToString());
        data.Add("repeat_tue", sun.ToString());
        data.Add("repeat_wed", sun.ToString());
        data.Add("repeat_thu", sun.ToString());
        data.Add("repeat_fri", sun.ToString());
        data.Add("repeat_sat", sun.ToString());

        WankoDB.Insert(table, data);
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
