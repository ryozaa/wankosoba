using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TodoData : MonoBehaviour
{
    public int id;
    public string title;
    public int tag;
    public int status;
    [SerializeField]
    GameObject todoself_;


    // Start is called before the first frame update
  public void Start()
    {

    }

  public void GoEdit()
  {
    var data = todoself_.GetComponent<TodoData>();
    globalmemory.Globalmemory.static_id = data.id;
    globalmemory.Globalmemory.static_title = data.title;
    globalmemory.Globalmemory.static_tag = data.tag;
    Debug.Log(globalmemory.Globalmemory.static_tag);

    SceneManagement.LoadEditScene();
  }
}
