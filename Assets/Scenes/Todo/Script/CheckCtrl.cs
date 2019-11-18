using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CheckOn()
    {
      var data = gameObject.GetComponent<TodoData>();
      var text = gameObject.transform.Find("TMPText").gameObject.GetComponent<TextMeshProUGUI>();

      if (data.status == 0)
      {
        data.status = 1;
        text.text = "<s><alpha=#88>" + data.title + "</s>";
      }
      else
      {
        data.status = 0;
        text.text = data.title;
      }
    }
}
