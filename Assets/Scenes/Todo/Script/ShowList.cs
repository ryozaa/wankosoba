using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowList : MonoBehaviour{


  [SerializeField]
  private RectTransform content_;

  [SerializeField]
  private GameObject todoPrefab_;

  GameObject content;
  GameObject[] todos;


    // Start is called before the first frame update
    void Start()
    {
      var result = TodoTable.FindAll();

      foreach(var record in result.Rows)
      {
        int id = (int) record["todo_id"];
        string title = (string) record["title"];
        int tag = (int) record["tag"];
        int status = (int) record["status"];

         var todo = Instantiate<GameObject>( todoPrefab_ );
         //
         todo.name = todoPrefab_.name;
         todo.transform.SetParent( content_, false );

         //todo.transform.Find("Text").gameObject.GetComponent<Text>().text = title;
         var data = todo.GetComponent<TodoData>();
         data.id = id;
         data.title = title;
         data.tag = tag;
         data.status = status;

        if(data.status == 0)
        {
         todo.transform.Find("TMPText").gameObject.GetComponent<TextMeshProUGUI>().text = data.title;
        }else if(data.status == 1)
        {
        todo.transform.Find("TMPText").gameObject.GetComponent<TextMeshProUGUI>().text = "<s><alpha=#88>" + data.title + "</s>";
        }
      }
      this.transform.Find("Add").SetSiblingIndex(result.Rows.Count);

      //SetActiveのためにあらかじめ取得
      content = GameObject.Find("Content");

    }

    // Update is called once per fram
    void Update()
    {

    }


    public void ShowAll()
    {
      foreach(Transform todocell in content.transform)
      {
        todocell.gameObject.SetActive(true);
      }
    }


    public void ShowRedtags()
    {
        foreach(Transform todocell in content.transform)
        {

          var data = todocell.gameObject.GetComponent<TodoData>();
          if (data.tag == 1 || data.tag == 2)
          {
            todocell.gameObject.SetActive(false);
          }
          else
          {
            todocell.gameObject.SetActive(true);
          }
        }
    }


    public void ShowBluetags()
    {
      foreach(Transform todocell in content.transform)
      {

        var data = todocell.gameObject.GetComponent<TodoData>();
        if (data.tag == 0 || data.tag == 2)
        {
          todocell.gameObject.SetActive(false);
        }
        else
        {
          todocell.gameObject.SetActive(true);
        }
      }
    }

    public void ShowGreentags()
    {
      foreach(Transform todocell in content.transform)
      {

        var data = todocell.gameObject.GetComponent<TodoData>();
        if (data.tag == 0 || data.tag == 1)
        {
          todocell.gameObject.SetActive(false);
        }
        else
        {
          todocell.gameObject.SetActive(true);
        }
      }
    }

    public void ShowDeleteButton()
    {
      foreach(Transform todocell in content.transform)
      {

        var deleteButton = todocell.Find("DeleteButton").gameObject;
        var editButton = todocell.Find("EditButton").gameObject;
        if(deleteButton.activeSelf == false)
        {
          editButton.SetActive(false);
          deleteButton.SetActive(true);
        }
        else
        {
          editButton.SetActive(true);
          deleteButton.SetActive(false);
        }
      }
    }
  }
