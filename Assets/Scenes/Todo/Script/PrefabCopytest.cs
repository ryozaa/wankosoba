using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabCopytest : MonoBehaviour{


  [SerializeField]
  private RectTransform content_;

  [SerializeField]
  private GameObject todoPrefab_;

    // Start is called before the first frame update
    void Start()
    {
      string[] result = {"買え物","散歩","掃除","todo4","todo5","todo6"};

      foreach(var record in result){
        // int id = (int) record["todo_id"];
        // string title = (string) record["title"];
        // int tag = (int) record["tag"];
        // int status = (int) record["status"];

         var todo = Instantiate<GameObject>(todoPrefab_);
         todo.transform.SetParent( content_, false );

         todo.transform.Find("Text").gameObject.GetComponent<Text>().text = record;
      }
      this.transform.Find("Add").SetSiblingIndex(result.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
