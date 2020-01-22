using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
          var canvas = GetComponentInParent<Canvas>();
          var body = GetComponent<Rigidbody2D>();

           //下に落とす ベクトル方向*速さ*
          body.velocity = new Vector2(0, -1) * 200 * canvas.transform.localScale.x;

    }

    void OnCollisionEnter2D()
    {
      var ball = FindObjectOfType<Ball>();
      //速度上昇
      ball.SpeedUp(100);
      Destroy( gameObject );
    }
}
