using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleTable
{
    private static string table = "schedule"; 

    public static void Insert(string date, string title, string detail, int icon, int remind, string time)
    {
        var data = new Dictionary<string, string>();
        data.Add("date", $"'{date}'");
        data.Add("title", $"'{title}'");
        data.Add("detail", $"'{detail}'");
        data.Add("icon", icon.ToString());
        data.Add("remind", remind.ToString());
        data.Add("time", $"'{time}'");

        WankoDB.Insert(table, data);
    }

    public static DataTable FindByDate(string date)
    {
        return WankoDB.FindBy(table, "date", $"'{date}'");
    }

    public static DataTable FindById(int id)
    {
        return WankoDB.FindBy(table, "schedule_id", id.ToString());
    }

    public static void Update(int id, string date, string title, string detail, int icon, int remind, string time) {
        var data = new Dictionary<string, string>();
        data.Add("date", $"'{date}'");
        data.Add("title", $"'{title}'");
        data.Add("detail", $"'{detail}'");
        data.Add("icon", icon.ToString());
        data.Add("remind", remind.ToString());
        data.Add("time", $"'{time}'");

        WankoDB.Update(table, data, "schedule_id", id.ToString());
    }

    public static void DeleteById(int id)
    {
        WankoDB.DeleteBy(table, "schedule_id", id.ToString());
    }
}
