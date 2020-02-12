using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SSResult : MonoBehaviour
{
    public static int score;
    public static int coin;
    public GameObject starObj;
    public Button retryButton;
    public Button titleButton;
    public Text scoreText;
    public Text coinText;

    void Start()
    {
        scoreText.text = "SCORE: " + score;
        coinText.text = "COIN: " + coin;

        PlayerPrefCtrl.SaveCoins(PlayerPrefCtrl.loadCoins() + coin);

        retryButton.onClick.AddListener(() => SceneManager.LoadScene("SobaShooting"));
        titleButton.onClick.AddListener(() => SceneManager.LoadScene("SSTitle"));
    }

    void Update()
    {
        if (Time.frameCount % 5 == 0) {
            Instantiate(starObj);
        }
    }
}
