using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D body;
    private float currentSpeed = 3f;
    private Transform playerTransform;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GetPlayer();
        Move();
    }

    private void Move()
    {
        if (playerTransform == null)
        {
            return;
        }
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    private void GetPlayer()
    {
        if (playerTransform == null)
        {
            playerTransform = GameManager.Instance.player.transform;
        }
    }
}
