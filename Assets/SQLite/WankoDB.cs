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

    public static DataTable FindAll(string table)
    {
        string query = $"select * from {table}";
        return db.ExecuteQuery(query);
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

    public static void Update(string table, Dictionary<string,string> data, string key, string value)
    {
      var updateList = new List<string>();

      foreach(KeyValuePair<string, string> kvp in data){
        Console.WriteLine($"{kvp.Key} = {kvp.Value}");
        updateList.Add($"{kvp.Key} = {kvp.Value}");
      }
      string updateStr = String.Join(",",updateList);
      string query = $"update {table} set {updateStr} where {key} = {value}";
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
