using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSEBullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(float direction, float speed, int type)
    {
        var v = new Vector2();
        v.x = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        v.y = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = v;
    }

    void Update()
    {
        if (!spriteRenderer.isVisible) {
            Destroy(gameObject);
        }
    }
}
