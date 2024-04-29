using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float currentSpeed = 5f;

    private float lifespan = 2.5f;
    private float lifeTimer;
    
    void OnEnable() {
        lifeTimer = lifespan;
    }

    void Update()
    {
        transform.Translate(Vector2.up * -1 * currentSpeed * Time.deltaTime);
        
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0)
        {
            AmmoPoolManager.Instance.ReturnAmmo(gameObject);
        }
    }
}
