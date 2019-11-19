using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SSGameManager : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject bossObj;
    public Text levelText;
    public Text scoreText;
    private int level = 1;
    private int score = 0;
    private int defeat = 0;
    private bool isBossBattle = false;

    void Start()
    {
        UpdateLabel();
    }

    void Update()
    {
        if (Time.frameCount % 120 == 0) {
            var pos = new Vector2(Random.Range(-2.3f, 2.3f), 5.3f);
            var enemy = (GameObject) Instantiate(enemyObj, pos, Quaternion.identity);
            enemy.GetComponent<SSEnemy>().Init(this, level);
        }
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
}
