using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Field : MonoBehaviour
{
  //ボールがこの領域を出た時の処理
    public void OnTriggerExit2D()
    {
      //今のシーンを終わらせてgameシーンを読み込む
      var game = GetComponentInParent<Game>();
      game.Miss();
    }
}
