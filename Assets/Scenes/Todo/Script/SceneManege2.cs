using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManege2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadAddScene()
    {
      SceneManager.LoadScene("ToDoAdd");
    }

    public void LoadEditScene()
    {

      SceneManager.LoadScene("ToDoEdit");
    }
}
