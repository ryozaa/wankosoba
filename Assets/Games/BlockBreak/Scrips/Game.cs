using System;
﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    //ブロックを追加するGameObject;
    [SerializeField]
    private Transform blocks_;
    [SerializeField]
    private GameObject blockprefab_;
    //スコア表示場所
    [SerializeField]
    private TextMeshProUGUI scoreText_;

        private static Transform Balls;
        [SerializeField]
        private Transform Balls_;
        private static GameObject SubBallprefab;
        [SerializeField]
        private GameObject SubBallprefab_;

    //アイテムのprefab達を格納場所とprefab
    [SerializeField]
    private Transform items_;
    [SerializeField]
    private GameObject[] itemPrefabs_;

    //life_は残機
    private static int life;
    private static int score_;
    private static int stageLv_;
    private List<int[]> blockList = new List<int[]>();
    private static bool stage1 = true;




    void Start(){

      if(Balls == null){
        Balls = Balls_;
      }
      if(SubBallprefab == null){
         SubBallprefab = SubBallprefab_;
      }
      //ブロック配置処理
      BlockSet();

      //stage1のときのみScoreと残機の初期化処理を行う
      if(stage1 == true){
      //scoreとlifeの初期化
      InitializationState();
      stage1 = false;
      }
      //score表示
      scoreText_.text = "SCORE: " + score_.ToString();
    }

    public void InitializationState(){
      //初期状態設定
      life = 3;
      score_ = 0;
      stageLv_ = 0;
    }


    void Update(){
      ClearCheck();
      }

    //クリア判定
    public static void ClearCheck(){
      //クリア判定を回している
      if(GameObject.FindWithTag("Block01") == null){
        ++stageLv_;
        Debug.Log("stageLv is "+ stageLv_ );
        SceneManager.LoadScene("BBGameScene");
      }
    }

    //ステージを読み込んでBlockを配置する処理
    public void BlockSet(){
      //csvからステージのブロックデータを読み込む
      TextAsset csvFile = Resources.Load("CSV/stageData") as TextAsset;
      StringReader reader = new StringReader (csvFile.text);
      while(reader.Peek() > -1){
        string line = reader.ReadLine();
        string[] strArray = line.Split(',');
        int[] intArray = Array.ConvertAll(strArray,v => int.Parse(v));
        blockList.Add(intArray);
      }
    //横に9個なので左に4個ずらして中央に合わせる
      int centering = 4;
      //5*5個ブロックを用意する
      for(int y = 0;y < 9; y++){
        for(int x = 0; x < 9; x++){
          int coordinate = blockList[y + stageLv_ * 9][x];

          if(coordinate == 0){
            continue;
          }

          var block = Instantiate<GameObject>( blockprefab_ );
          //新規GameObjectの親を設定されたGameObjectにする
          block.transform.SetParent( blocks_, false );
          block.GetComponent<Block>().SetValue( coordinate );
          //座標の調整
          var transform = block.GetComponent<RectTransform>();
          var rect = transform.rect; //ブロックの大きさ
          //カラー変更
          var image = block.GetComponent<Image>();
          //xは0が真ん中
          //　-1*widthでブロック1つ分左,1*widthでブロック1つ分右に
          //yは0が一番上、0だと壁にめり込むので150下に下げる
          //そこからwidth毎に下にずれる
          transform.anchoredPosition = new Vector2(
            (x - centering) * rect.width,
            -y * rect.height - (150+50) ); //上部壁の座標＋隙間
            //180~250,100,80~100
            if(coordinate == 3){
              image.color = new Color(0.65f,0.65f,0.65f);
            }else{
              //image.color = Color.HSVToRGB((180.0f + (float)y*14.0f)/360.0f, (50.0f + (5.0f-(float)x)*10.0f)/100.0f, 100.0f/100.0f);
            }

        }//x
      }//y

    }

    public void CreateItem( Vector2 position ){
      //どのアイテムが落ちるかを抽選　今の出現率は平等
      int randomItemNo = UnityEngine.Random.Range( 0, itemPrefabs_.Length );
      GameObject itemPrefab = itemPrefabs_[randomItemNo];

      GameObject newItem = Instantiate( itemPrefab );

      var transform = newItem.GetComponent<RectTransform>();
      transform.SetParent( items_,false );

      transform.position = position;
    }


    //一機増える　それだけ
    public void OneUp(){
      ++life;
    }

  //Score処理
    public void Addscore( int score ){
      score_ += score;
      scoreText_.text = "SCORE:" + score_.ToString();
    }

    public static int Score{
      get { return score_; }
    }

    public static int StageLv{
      get{ return stageLv_; }
    }

    public void Miss(){
        --life;
        if(life <= 0){
          //ここでは初期化しないように変更
          //stageLv_ = 0;
          stage1 = true;
          SceneManager.LoadScene("BBGameOver");
        }else{
          //ボールを子の中から取得
          var ball = GetComponentInChildren<Ball>();
          ball.Reset();
        }
    }

    public static void SpownSubBall(){
      var subBall = Instantiate<GameObject>(SubBallprefab,Balls);

    }

  }
