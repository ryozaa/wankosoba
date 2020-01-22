using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bar : MonoBehaviour
{
  public void OnTouch( BaseEventData arg )
  {
    //EventTriggerでは汎用の為引数はBaseEventDataですが、ドラッグのイベントでは実態はPointerEventDataなのでキャストしています
    PointerEventData e = arg as PointerEventData;

    var transform = GetComponent<RectTransform>();
    var position = transform.position; //今のtransformの座標を取得
    position. x = e.position.x; //ドラッグされている場所を代入
    transform.position = position;　//transformに座標を反映
    //ここに押されているときの処理を記述する
    //Debug.Log( e.position );

    //座標xが-500以下なら-500に、500以上なら500になるようにする
    var localPosition = transform.anchoredPosition;
    localPosition.x = Mathf.Clamp( localPosition.x, -500, 500 );
    transform.anchoredPosition = localPosition;

  }

  void OnCollisionEnter2D( Collision2D collision )
  {
      var tag = collision.gameObject.tag;
      if(tag == "Ball"){
      var point = collision.contacts[0].point.x - transform.position.x;
      var rate = point/(GetComponent<RectTransform>().rect.width * .5f);
      var ball = collision.contacts[0].collider.GetComponent<Ball>();
      var angle = rate * 30;
      angle = Mathf.Clamp(angle,-60,60);
      Debug.Log(angle);
      ball.Rotate( angle );

       //Debug.Log( "衝突座標:" + collision.contacts[0].point );
       //Debug.Log( "自機との差:" + point );
     }
  }

}
