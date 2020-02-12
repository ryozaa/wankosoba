using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

  public int hp_;


    // Start is called before the first frame update
    void Start()
    {
      // if(Game.blockHp == 3){
      //   hp_ = 1000;
      // }
      // else{
      // Debug.Log("Block's" + Game.blockHp);
      // hp_ = Game.blockHp;

    }

    public void SetValue(int v)
    {
      if(v == 3){
        this.hp_ =int.MaxValue;

      }else{
        this.hp_ = v;
        this.gameObject.tag = "Block01";
      }
    }

    void OnCollisionExit2D()
    {
      --hp_;
      if(hp_ <= 0 ){
        var game = GetComponentInParent<Game>();
        game.Addscore( 100 );
        //アイテムの出現確率は20%
        int randomValue = Random.Range(0,100);
        if(randomValue < 50){
        game.CreateItem( transform.position );
        }
        //ブロックの消滅
        Destroy( gameObject );
        //Debug.Log("OnCollision");


      }
    }
}
