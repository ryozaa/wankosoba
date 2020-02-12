using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class SSGameManager : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject bossObj;
    public GameObject starObj;
    public Text levelText;
    public Text scoreText;
    public static int level = 1;
    public static int score = 0;
    private int defeat = 0;
    private bool isBossBattle = false;
    private Sequence sequence;

    void Start()
    {
        level = 1;
        score = 0;

        UpdateLabel();
        sequence = DOTween.Sequence()
            .AppendInterval(2f)
            .AppendCallback(createEnemy)
            .SetLoops(-1);
    }

    void Update()
    {
        if (Time.frameCount % 5 == 0) {
            Instantiate(starObj);
        }
    }

    public void createEnemy()
    {
        var pos = new Vector2(Random.Range(-2.3f, 2.3f), 5.3f);
        var enemy = (GameObject)Instantiate(enemyObj, pos, Quaternion.identity);
        enemy.GetComponent<SSEnemy>().Init(this, level);
    }

    public void EnemyDefeat()
    {
        score += 100;
        UpdateLabel();
        if (isBossBattle) return;
        if (++defeat % 5 == 0) {
            isBossBattle = true;
            var pos = new Vector2(0, 4f);
            var boss = (GameObject)Instantiate(bossObj, pos, Quaternion.identity);
            boss.GetComponent<SSBoss>().Init(this, level);
        }
    }

    public void BossDefeat()
    {
        isBossBattle = false;
        score += 500 * level;
        level ++;
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        scoreText.text = score.ToString();
        levelText.text = level.ToString();
    }

    public void GameOver()
    {
        SSResult.score = score;
        SSResult.coin = (level - 1) * 100;
        
        sequence.Kill();
        Invoke("loadResultScene", 3f);
    }

    private void loadResultScene()
    {
        SceneManager.LoadScene("SSResult");
    }
}
