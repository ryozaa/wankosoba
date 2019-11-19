using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SSEnemy : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject Bullet;
    public GameObject HitEffect;
    public GameObject expEffect;
    private SSGameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private int hp;
    private int offset;

    void Start()
    {
        DOTween.Sequence()
            .AppendCallback(Shot)
            .AppendInterval(2f)
            .SetLoops(-1);
        spriteRenderer = GetComponent<SpriteRenderer>();
        offset = -70 - (int) Mathf.Floor(transform.position.x / 2.3f * 25);
    }

    public void Init(SSGameManager gameManager, int level)
    {
        int hp = level;
        float speed = 1 + level * 0.1f;

        this.gameManager = gameManager;
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
        this.hp = level;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, -speed);
    }

    void Shot()
    {
        for (int i = 0; i < 3; i++) {
            var clone = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
            clone.GetComponent<SSEBullet>().Init(offset -20*i, 2.5f, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Instantiate(HitEffect, coll.transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        if (--hp == 0) {
            Instantiate(expEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameManager.EnemyDefeat();
        }
    }

    void Update()
    {
        if (!spriteRenderer.isVisible) {
            Destroy(gameObject);
        }
    }
}
