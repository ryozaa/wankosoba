using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  public class TouchManager
  {
    public bool _touch_flag;
    public vector2 _touch_position;
    public TouchPhase _touch_phase;

    public TouchManager(bool flag =false, Vector2? position = null ,TouchPhase phase = TouchPhase.Began){
      this._touch_flag = flag;
      if(position == null){
        this._touch_position = new Vector2(0,0);
      } else {
        this._touch_position = (vector2)position;
      }
      this._touch_phase =phase;
  }

  public class TouchController : MonoBehaviour
  {
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
        this._touch_flag = false;
        //エディタと実機の処理分け
        if (Application.isEditor){
          //エディタ実行
          if(Input.GetMouseButtonDown(0)){
            this._touch_flag = true;
            this._touch_phase = TouchPhase.Began;
            Debug.Log("クリック押した瞬間");
          }
          if(Input.GetMouseButtonUp(0)){
            this._touch_flag = true;
            this._touch_phase = TouchPhase.Ended;
            Debug.Log("クリック離した瞬間");
          }
          if(Input.GetMouseButton(0)){
            this._touch_flag = true;
            this._touch_phase = TouchPhase.Moved;
            Debug.Log("クリック押しっぱなし");
          }
          if (this._thouch_flag) this._touch_position = Input.mousePosition;

        } else {
          //実機で実行
          //タッチされているか確認
          if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            this._touch_position = touch.position;
            this._touch_phase = touch.phase;
            this._touch_flag = true;
          }

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

        public TouchManager getTouch(){
          return new TouchManager(this._touch_flag,this._touch_position,this._touch_phase);
        }

      }
  }
