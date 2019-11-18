
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  //public string name;
  public Button addbutton;
  public Button editbutton;


    // Start is called before the first frame update
    void Start()
    {
      addbutton.onClick.AddListener(() => SceneManagement.LoadAddScene());
      editbutton.onClick.AddListener(() => SceneManagement.LoadEditScene());
    }

    // Update is called once per frame
    void Update()
    {

    }


      public static void LoadAddScene()
      {
        SceneManager.LoadScene("ToDoAdd");
      }

      public static void LoadEditScene()
      {

        SceneManager.LoadScene("ToDoEdit");
      }
}
