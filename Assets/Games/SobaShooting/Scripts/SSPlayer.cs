using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSPlayer : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        var moveLimit = new Vector2(2.3f, 4.5f);

        TouchInput.Moved += e => {
            var delta = e.deltaScreenPoint;
            var pos = transform.position;
            transform.position = new Vector3(
                Mathf.Clamp(pos.x + delta.x/125, -moveLimit.x, moveLimit.x),
                Mathf.Clamp(pos.y + delta.y/125, -moveLimit.y, moveLimit.y),
                0
            );
        };
    }

    void Update()
    {
        if (Time.frameCount % 10 == 0) {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject);
    }
}
