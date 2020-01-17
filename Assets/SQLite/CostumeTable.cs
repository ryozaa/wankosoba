using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeTable
{
    private static string table = "costume"; 

    public static DataTable FindAll()
    {
        return WankoDB.FindAll(table);
    }

    public static void Insert(int id, int type, string desc, int price)
    {
        var data = new Dictionary<string, string>();
        data.Add("costume_id", id.ToString());
        data.Add("type", type.ToString());
        data.Add("description", $"'{desc}'");
        data.Add("price", price.ToString());
        data.Add("status", "0");

        WankoDB.Insert(table, data);
    }

    public static DataTable FindById(int id)
    {
        return WankoDB.FindBy(table, "costume_id", $"'{id}'");
    }

    public static DataTable FindByType(int type)
    {
        return WankoDB.FindBy(table, "type", type.ToString());
    }
}
