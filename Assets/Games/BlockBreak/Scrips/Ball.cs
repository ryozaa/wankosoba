using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

  private float speed_;


    void Start()
    {
      Debug.Log("Start Awake" + Time.frameCount);
      Reset();
    }


    public void Reset()
    {
        //このGameObjectに付与されている物理演算コンポネントを取得
        var body = gameObject.GetComponent<Rigidbody2D>();
        //画面描画用のCanvasを取得
        var canvas = GetComponentInParent<Canvas>();
        Debug.Log("Reset Awake");
        speed_ = 640;

        //ボールを動かす向き:右上
        //normalized(正規化)で大きさ1ベクトルに
        var direction = new Vector2( 1, 1 ).normalized;

        //velocity(速度)を設定する。
        //この速さは秒速。上でdirectionの大きさは1にしているので1*640=640が速さになる
        body.velocity = direction * speed_ * canvas.transform.localScale.x;
        //位置を0に
        transform.localPosition = Vector3.zero;
    }


    public void Rotate( float angle )
    {
      //Ballのコンポーネントを取得
      var body = gameObject.GetComponent<Rigidbody2D>();
      //画面描画用のCanvasを取得
      var canvas = GetComponentInParent<Canvas>();
      //今の速度
      var velocity =body.velocity;
      //angle度回転させる
      velocity = Quaternion.Euler( 0, 0, angle ) * velocity;
      //velocity(x,y);
      //計算誤差で大きさが変わってるかもしれないので計算しなおす
      body.velocity = velocity.normalized * speed_ * canvas.transform.localScale.x;
    }

    private void UpdateVelocity()
    {
      var body = gameObject.GetComponent<Rigidbody2D>();
      var canvas = GetComponentInParent<Canvas>();

      body.velocity = body.velocity.normalized * speed_ * canvas.transform.localScale.x;
      Debug.Log("SPEED:" + speed_);
    }


    public void SpeedUp(float addition)
    {
      speed_ += addition;
      Debug.Log("Speed:" + speed_);
      UpdateVelocity();
    }
}
