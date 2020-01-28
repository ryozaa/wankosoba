using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSubBall : MonoBehaviour
{

  [SerializeField]
  private Transform Balls_;
  [SerializeField]
  private GameObject SubBallprefab_;

    public static void Generate()
    {
      //var subBall = Instantiate<GameObject>(SubBallprefab_);
      //subBall.transform.SetParent(Balls_ ,false );
      //Destroy( gameObject );
    }
}
