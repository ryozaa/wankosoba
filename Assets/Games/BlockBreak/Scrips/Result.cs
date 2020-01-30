using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{

  [SerializeField]
  private GameObject scoreText_;
  [SerializeField]
  private GameObject stageLvText_;
  [SerializeField]
  private GameObject coinText_;

  private int coin;
  int gameScore = 1000;
  int count = 0;
    // Start is called before the first frame update
    void Start(){

      coin = Game.Score/10000;
      //
      // for(count = 0; count > gameScore; count++){
      //   scoreCount();
      // }
       scoreText_.GetComponent<TextMeshProUGUI>().text = Game.Score.ToString();
       stageLvText_.GetComponent<TextMeshProUGUI>().text = Game.StageLv.ToString();
       coinText_.GetComponent<TextMeshProUGUI>().text = coin.ToString();

    }

    void scoreCount(){

        Debug.Log(count);
        scoreText_.GetComponent<TextMeshProUGUI>().text = count.ToString();

    }
    // Update is called once per frame
    void Update()
    {

    }


}
