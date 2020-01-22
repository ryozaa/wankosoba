using UnityEngine;
using System.Collections;

public class Array2D
{

int _width;
int _height;
int _outOfRange =-1;
int[] _values = null;//マップデータ

public int Width{
  get{ return _width; }
}

public int Height {
  get{ return _height; }
  }

public void Create(int width,int height){
  _width = width;
  _height = height;
  _values = new int[Width * Height];
}

//座標をインデックスに変換する
public int ToIdx(int x, int y){
  return x + ( y * Width );
}

//領域外かどうかのチェック
public bool IsOutOfRange(int x, int y){
  if(x < 0 || x >= Width ){ return true; }
  if(y < 0 || y >= Height ){ return true; }

  return false;
}

//@return 指定の座標の値(領域外を指定したら_outOfRangeを返す)
public int Get(int x, int y){
  if(IsOutOfRange(x, y)){
    return _outOfRange;
  }
  return _values[y * Width + x];
}

//
public void Set(int x, int y, int v){
  if(IsOutOfRange(x, y)){
    return;
  }
  _values[y * Width + x] = v;
}

public void Dump(){
  Debug.Log("[Array2D] (w,h)=("+Width+","+Height+")");
  for(int y = 0; y < Height; y++){
    string s = "";
    for(int x = 0; x < Width; x++){
      s += Get(x, y) + ",";
    }
    Debug.Log(s);
  }
}

}
