using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSExpEffect : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (frame == 5) {
            Destroy(gameObject);
            return;
        }

        spriteRenderer.sprite = sprites[frame];
        if (Time.frameCount % 2 == 0) frame++;
    }
}
