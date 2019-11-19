using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSBullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, 10);
    }

    void Update()
    {
        if (!spriteRenderer.isVisible) {
            Destroy(this.gameObject);
        }
    }
}
