using System;
using System.Collections;
using System.Collections.Generic;

public class WankoDB
{
    private static SqliteDatabase db = new SqliteDatabase("wankosoba.db");

    public static void Insert(string table, Dictionary<string, string> data)
    {
        string keys = String.Join(",", new List<string>(data.Keys));
        string values = String.Join(",", new List<string>(data.Values));

        string query = $"insert into {table} ({keys}) values ({values})";
        db.ExecuteNonQuery(query);
    }

    public static DataTable FindBy(string table, string key, string value)
    {
        string query = $"select * from {table} where {key} = {value}";
        return db.ExecuteQuery(query);
    }

    public static void DeleteBy(string table, string key, string value)
    {
        string query = $"delete from {table} where {key} = {value}";
        db.ExecuteNonQuery(query);
    }

    public static DataTable ExecuteQuery(string query)
    {
        return db.ExecuteQuery(query);
    }

    public static void ExecuteNonQuery(string query)
    {
        db.ExecuteNonQuery(query);
    }
}
