using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //エディタと実機の処理分け
      if (Application.isEditor){
        //エディタ実行
        if(Input.GetMouseButtonDown(0)){
          Debug.Log("クリック押した瞬間");
        }
        if(Input.GetMouseButtonUp(0)){
          Debug.Log("クリック離した瞬間");
        }
        if(Input.GetMouseButton(0)){
          Debug.Log("クリック押しっぱなし");
        }

      } else {
        //実機で実行
        //タッチされているか確認
        if(Input.touchCount > 0){
          Touch touch = Input.GetTouch(0);

          if(touch.phase == TouchPhase.Began){
            Debug.Log("押した瞬間");
          }
          if(touch.phase == TouchPhase.Ended){
            Debug.Log("離した瞬間");
          }
          if(touch.phase == TouchPhase.Moved){
            Debug.Log("押しっぱなし");
          }

        }
      }

    }
}
