using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteTodo()
    {
      var data = gameObject.GetComponent<TodoData>();
      TodoTable.DeleteById(data.id);
      Destroy(this.gameObject);
    }
}
