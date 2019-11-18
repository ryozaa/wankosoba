using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditSceneManeger : MonoBehaviour
{
  static int tagNum = 0;
  GameObject refObj;

  [SerializeField]
  public InputField TargetInputField;
    // Start is called before the first frame update
    void Start()
    {

      //値引き渡し
      TargetInputField.text = globalmemory.Globalmemory.static_title;
      //タグ表示
      tagNum = globalmemory.Globalmemory.static_tag;
      Debug.Log(tagNum);
      if(tagNum == 1){
        refObj = GameObject.Find("BluetagButton");
        var tagctl = refObj.GetComponent<TagOn>();
        tagctl.BluetagisOn();
        Debug.Log("blue");
      }
      if(tagNum == 2){
        refObj = GameObject.Find("GreentagButton");
        var tagctl = refObj.GetComponent<TagOn>();
        tagctl.GreentagisOn();
        Debug.Log("Green");
      }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public　void ToDoTableUpdate(){
      //入力をDBに
      string title = TargetInputField.text;
      int tag = tagNum;
      int id = globalmemory.Globalmemory.static_id;
      TodoTable.Update(title,tag,id);
    }

    public void UpdateOnclick()
    {
      ToDoTableUpdate();
      SceneManager.LoadScene("TodoList");
    }
    //これらはあとでAddと統合する
    public void ChangeToRedTag()
    {
      if(tagNum != 0){
        tagNum = 0;
      }
    }

    public void ChangeToBlueTag()
    {
      if(tagNum != 1){
        tagNum = 1;
      }
    }

    public void ChangeToGreenTag()
    {
      if(tagNum != 2){
        tagNum = 2;
      }
    }




}
