using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SubBallSpownItem : MonoBehaviour
{


    [SerializeField]
    private Transform Balls_;
    [SerializeField]
    private GameObject SubBallprefab_;

    // Start is called before the first frame update
    void Start()
    {
          var canvas = GetComponentInParent<Canvas>();
          var body = GetComponent<Rigidbody2D>();

           //下に落とす ベクトル方向*速さ*
          body.velocity = new Vector2(0, -1) * 200 * canvas.transform.localScale.x;

    }

    public void OnCollisionEnter2D()
    {
      Game.SpownSubBall();
      Destroy( gameObject );
    }
}
