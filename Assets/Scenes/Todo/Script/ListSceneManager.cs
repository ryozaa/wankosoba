using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class ListSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] redtags;
    private GameObject[] bluetags;
    private GameObject[] greentags;
    void Start()
    {
      //各タグのついてるオブジェクトをあらかじめロードする
      redtags = GameObject.FindGameObjectsWithTag("RedTag");
      bluetags = GameObject.FindGameObjectsWithTag("BlueTag");
      greentags = GameObject.FindGameObjectsWithTag("GreenTag");
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddButtonClicked()
    {
      SceneManager.LoadScene("ToDoAdd");
    }

    public void EditButtonClicked()
    {
      SceneManager.LoadScene("ToDoEdit");
    }


    public void RedTagToggle()
    {

      foreach(GameObject redtag in redtags){
        redtag.SetActive(true);
      }
      foreach(GameObject bluetag in bluetags){
        bluetag.SetActive(false);
      }
    }

    public void BlueTagToggle()
    {

      foreach(GameObject bluetag in bluetags){
        bluetag.SetActive(true);
      }
      foreach(GameObject redtag in redtags){
        redtag.SetActive(false);
      }
    }

}
