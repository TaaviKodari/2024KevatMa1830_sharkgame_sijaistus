using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;
    public GameObject enemyPrefab;
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
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.SetActive(false);
            pool.Enqueue(newEnemy);
        }
    }

    public GameObject GetEnemy()
    {
        if (pool.Count > 0)
        {
            GameObject enemy = pool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            return newEnemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        pool.Enqueue(enemy);
    }
}
