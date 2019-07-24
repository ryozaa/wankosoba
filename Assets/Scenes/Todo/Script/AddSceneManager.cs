using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddSceneManager : MonoBehaviour
{
  public Button Cancel;
  public Button Add;
  InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
      //InputFieldコンポーネントの取得と初期化メソッドの実行
      inputField = GetComponent<InputField>();
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
      //フォーカス(って何)
      inputField.ActivateInputField();
    }

    public void AddOnclick()
    {
      Debug.Log("更新ボタン");
      SceneManager.LoadScene("TodoList");
    }

    public void CancelOnclick()
    {
      Debug.Log("キャンセルボタン");
      SceneManager.LoadScene("TodoList");
    }

}
