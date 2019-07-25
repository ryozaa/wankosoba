

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public string name;

  public void AddButtonClicked(){
    SceneManager.LoadScene("ToDoAdd");
  }

  public void EditButtonClicked(){
    SceneManager.LoadScene("ToDoEdit");
  }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
