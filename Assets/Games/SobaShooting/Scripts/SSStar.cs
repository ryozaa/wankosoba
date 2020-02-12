using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSStar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float scale;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = new Vector3(Random.Range(-2.8f, 2.8f), 5f, 1);

        scale = Random.Range(0.2f, 1f);
        transform.localScale = new Vector3(scale, scale, 1);

        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, -scale * 10);
    }

    void Update()
    {
        if (!spriteRenderer.isVisible) {
            Destroy(this.gameObject);
        }
    }
}
