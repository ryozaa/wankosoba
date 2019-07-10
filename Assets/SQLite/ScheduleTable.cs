using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleTable
{
    private static SqliteDatabase db = new SqliteDatabase("wankosoba.db");

    public static void Insert(string date, string title, string detail, int icon, int remind, string time)
    {
        string query = $@"insert into schedule(date, title, detail, icon, remind, time) values (
            '{date}','{title}', '{detail}', {icon}, {remind}, '{time}'
        )";
        db.ExecuteNonQuery(query);
    }

    public static DataTable FindByDate(string date)
    {
        string query = $"select * from schedule where date = '{date}'";
        return db.ExecuteQuery(query);
    }
}
