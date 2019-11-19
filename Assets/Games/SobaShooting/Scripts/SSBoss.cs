using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBoss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject HitEffect;
    public GameObject expEffect;
    public Sprite[] sprites;
    private SSGameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private int hp = 200;
    private int frame = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(SSGameManager gameManager, int level)
    {
        this.gameManager = gameManager;
        hp = level * 5;
    }

    void Update()
    {
        var frameCount = Time.frameCount;
        if (frameCount % 5 == 0) spriteRenderer.sprite = sprites[++frame % 4];
        if (frameCount % 120 == 0) Shot();

        var p = transform.position;
        transform.position = new Vector3(Mathf.Sin(frameCount/15f) * 2.3f, p.y, p.z);
    }

    void Shot()
    {
        int offset = Random.Range(0, 30);
        for (int i = 0; i < 12; i++) {
            var clone = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
            clone.GetComponent<SSEBullet>().Init(offset + i*30, 2f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Instantiate(HitEffect, coll.transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        if (--hp == 0) {
            Instantiate(expEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameManager.BossDefeat();
        }
    }
}
