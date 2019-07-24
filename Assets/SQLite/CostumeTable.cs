using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeTable
{
    private static string table = "costume"; 

    public static DataTable FindById(int id)
    {
        return WankoDB.FindBy(table, "costume_id", $"'{id}'");
    }

    public static DataTable FindByType(int type)
    {
        return WankoDB.FindBy(table, "type", type.ToString());
    }
}
