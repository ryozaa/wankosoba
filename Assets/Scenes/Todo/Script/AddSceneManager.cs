using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddSceneManager : MonoBehaviour
{
  static int tagNum = 0;
  InputField inputField;

  [SerializeField]
   private GameObject inputFieldobj;
    // Start is called before the first frame update
    void Start()
    {
      //InputFieldコンポーネントの取得と初期化メソッドの実行
      inputField = inputFieldobj.GetComponent<InputField>();
      InitInputField();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void InputLogger()
    {
     string inputValue = inputField.text;
     Debug.Log(inputValue);
     InitInputField();
    }

    public void InitInputField()
    {
      //使うインプットフィールドを有効にする
      inputField.ActivateInputField();
    }


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


    public void AddOnclick()
    {
      ToDoTableControll(); //本番用接続
      Debug.Log("追加ボタン");
      SceneManager.LoadScene("TodoList");

    }

    public　void ToDoTableControll(){
      //入力をDBに書きこむ
      string title = inputField.text;
      int tag = tagNum;
      int status = 0;
      TodoTable.Insert(title,tag,status);
    }

    public void CancelOnclick()
    {
      Debug.Log("キャンセルボタン");
      SceneManager.LoadScene("TodoList");
    }

}
