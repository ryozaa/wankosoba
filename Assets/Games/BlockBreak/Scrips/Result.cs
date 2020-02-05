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

  [SerializeField]
  private Button RetryButton;
  [SerializeField]
  private Button TitleButton;

  //private int coin;
  //int gameScore = 1000;
  int count = 0;
    // Start is called before the first frame update
    public void Start(){

      int coin = Game.Score/1000;
      Debug.Log(coin);
      int stageLv = Game.StageLv + 1;
      //
      // for(count = 0; count > gameScore; count++){
      //   scoreCount();
      // }
       scoreText_.GetComponent<TextMeshProUGUI>().text = Game.Score.ToString();
       stageLvText_.GetComponent<TextMeshProUGUI>().text = stageLv.ToString();
       coinText_.GetComponent<TextMeshProUGUI>().text = coin.ToString();

       RetryButton.onClick.AddListener(Retry);
       TitleButton.onClick.AddListener(ToTitle);
    }

    public void scoreCount(){

        Debug.Log(count);
        scoreText_.GetComponent<TextMeshProUGUI>().text = count.ToString();

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ToTitle(){
      SceneManager.LoadScene("BBTitleScene");
    }
    public void Retry(){
      SceneManager.LoadScene("BBGameScene");
    }


}
