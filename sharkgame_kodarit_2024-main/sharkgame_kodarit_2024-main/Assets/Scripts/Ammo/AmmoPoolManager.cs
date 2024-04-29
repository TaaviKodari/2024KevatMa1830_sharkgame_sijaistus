using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPoolManager : MonoBehaviour
{
    public static AmmoPoolManager Instance;
    public GameObject ammoPrefab;
    private int poolSize = 20;
    private Queue<GameObject> pool = new Queue<GameObject>();
    
    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newAmmo = Instantiate(ammoPrefab);
            newAmmo.SetActive(false);
            pool.Enqueue(newAmmo);
        }
    }

    public GameObject GetAmmo()
    {
        if (pool.Count > 0)
        {
            GameObject ammo = pool.Dequeue();
            ammo.SetActive(true);
            return ammo;
        }
        else
        {
            GameObject newAmmo = Instantiate(ammoPrefab);
            return newAmmo;
        }
    }

    public void ReturnAmmo(GameObject ammo)
    {
        ammo.SetActive(false);
        pool.Enqueue(ammo);
    }
}
