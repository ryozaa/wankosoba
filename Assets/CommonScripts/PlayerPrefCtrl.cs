using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefCtrl : MonoBehaviour
{

  public static void SaveCoins(int coins)
  {
    PlayerPrefs.SetInt("COINS",coins);
    PlayerPrefs.Save();
  }

  public static loadCoins()
  {
    int coins = PlayerPrefs.GetInt("COINS",0);
    return coins;
  }

}
