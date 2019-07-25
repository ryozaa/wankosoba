using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CoinManager : MonoBehaviour{

  public GameObject coin_object = null; // Textオブジェクト
  public int coin_num = 0; // コイン変数

    // Start is called before the first frame update
    void Start(){
       coin_num = PlayerPrefs.GetInt ("COIN", 0);
    }

    // Update is called once per frame
    void Update(){
      //CoinTextオブジェクトから"Text"のコンポーネントを取得
      Text coin_text = coin_object.GetComponent<Text> ();
      // テキストの表示を入れ替える
      coin_text.text = coin_num.ToString();
    }
}
