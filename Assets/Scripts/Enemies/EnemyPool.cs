using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [Header("Pool Settings")]
    public EnemyConfig enemyConfig;
    public int initialPoolSize = 10;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    [SerializeField] private Transform spawnPosition;

    private void Awake()
    {
        //InitializePool();
    }

    //private void InitializePool()
    //{
    //    for (int i = 0; i < initialPoolSize; i++)
    //    {
    //        CreateNewEnemy();
    //    }
    //}

    private void CreateNewEnemyInPool()
    {
        GameObject enemy = Instantiate(enemyConfig.enemyPrefab, spawnPosition.position, Quaternion.identity, transform);
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
        //return enemy;
    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else
        {
            CreateNewEnemyInPool();
            return GetEnemy();
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
