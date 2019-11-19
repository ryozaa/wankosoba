using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSHitEffect : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (frame == 3) {
            Destroy(gameObject);
            return;
        }

        spriteRenderer.sprite = sprites[frame];
        if (Time.frameCount % 2 == 0) frame ++;
    }
}
