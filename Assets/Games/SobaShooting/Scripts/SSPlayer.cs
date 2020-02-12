using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SSPlayer : MonoBehaviour
{
    public SSGameManager gameManager;
    public GameObject bullet;
    public GameObject expEffect;
    private Sequence sequence;
    private Vector2 moveLimit = new Vector2(2.3f, 4.5f);

    void Start()
    {
        var moveLimit = new Vector2(2.3f, 4.5f);

        TouchInput.Moved += onMove;

        sequence = DOTween.Sequence()
            .AppendInterval(0.2f)
            .AppendCallback(Shot)
            .SetLoops(-1);
    }

    void Shot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void onMove(TouchInfo e)
    {
        var delta = e.deltaScreenPoint;
        var pos = transform.position;
        transform.position = new Vector3(
            Mathf.Clamp(pos.x + delta.x / 50, -moveLimit.x, moveLimit.x),
            Mathf.Clamp(pos.y + delta.y / 50, -moveLimit.y, moveLimit.y),
            0
        );
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(coll.gameObject);
        Destroy(this.gameObject);
        sequence.Kill();
        TouchInput.Moved -= onMove;
        gameManager.GameOver();
    }
}
