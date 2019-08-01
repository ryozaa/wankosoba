using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoTable
{
    private static string table = "todo";

    public static void Insert(string title, int tag, int status)
    {
        var data = new Dictionary<string, string>();
        data.Add("title", $"'{title}'");
        data.Add("tag", tag.ToString());
        data.Add("status", status.ToString());

        WankoDB.Insert(table, data);
    }

    public static DataTable FindAll()
    {
        return WankoDB.FindAll(table);
    }

    public static DataTable FindById(int id)
    {
        return WankoDB.FindBy(table, "todo_id", id.ToString());
    }

    public static void DeleteById(int id)
    {
        WankoDB.DeleteBy(table, "todo_id", id.ToString());
    }

    public static void UpdateToDo(string title, int tag, int id)
    {
       var data = new Dictionary<string, string>();
       data.Add("title", $"'{title}'");
       data.Add("tag", tag.ToString());
       WankoDB.Update(table, data, "todo_id", id.ToString());
    }

    public static void UpdateStatus(int status, int id)
    {
       var data = new Dictionary<string, string>();
       data.Add("status", status.ToString());
       WankoDB.Update(table, data, "todo_id", id.ToString());
    }

}
