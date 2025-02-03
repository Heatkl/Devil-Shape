using System;
using System.Collections;
using UnityEngine;

using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action OnWaveCleared;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public Transform destinationPoint;
    private int aliveEnemies = 0;

    [Header("References")]
    public EnemyPool enemyPool;

    private WaveSettings currentWave;
    private float waveFactor = 1.1f;
    public void StartWaveSpawn(WaveSettings waveSettings, float waveFactor)
    {
        this.waveFactor = waveFactor;
        currentWave = waveSettings;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        switch (currentWave.spawnType)
        {
            case EnemySpawnType.Together:
                yield return StartCoroutine(SpawnTogether());
                break;

            case EnemySpawnType.OneByOne:
                yield return StartCoroutine(SpawnOneByOne());
                break;

            case EnemySpawnType.Random:
                yield return StartCoroutine(SpawnRandom());
                break;
        }

        while (aliveEnemies != 0)
        {
            yield return null;
        }
        
            OnWaveCleared?.Invoke();
            Debug.LogWarning("ClearedInSpawner");
        
    }

    private IEnumerator SpawnTogether()
    {
        foreach (var enemyWave in currentWave.enemies)
        {
            for (int i = 0; i < enemyWave.waveEnemiesCount; i++)
            {
                SpawnEnemy(enemyWave.enemyConfig);
            }
        }
        yield break;
    }

    private IEnumerator SpawnOneByOne()
    {
        foreach (var enemyWave in currentWave.enemies)
        {
            for (int i = 0; i < enemyWave.waveEnemiesCount; i++)
            {
                SpawnEnemy(enemyWave.enemyConfig);
                yield return new WaitForSeconds(enemyWave.timeBetweenEnemiesSpawn);
            }
        }
    }

    private IEnumerator SpawnRandom()
    {
        while (HasEnemiesLeft())
        {
            foreach (var enemyWave in currentWave.enemies)
            {
                if (enemyWave.waveEnemiesCount > 0)
                {
                    SpawnEnemy(enemyWave.enemyConfig);
                    enemyWave.waveEnemiesCount--;
                    yield return new WaitForSeconds(enemyWave.timeBetweenEnemiesSpawn);
                }
            }
        }
    }

    private bool HasEnemiesLeft()
    {
        foreach (var enemyWave in currentWave.enemies)
        {
            if (enemyWave.waveEnemiesCount > 0) return true;
        }
        return false;
    }

    private void SpawnEnemy(EnemyConfig enemyConfig)
    {
        GameObject enemy = Instantiate(enemyConfig.enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().Init(enemyConfig.rewardPerUnit, destinationPoint.position, enemyConfig.speed, waveFactor);

        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        health.OnDeath += HandleEnemyDeath;

        aliveEnemies++;
        GameActions.EnemyChange.Invoke(aliveEnemies);
    }

    private void HandleEnemyDeath(EnemyHealth enemy)
    {
        aliveEnemies--;
        GameActions.EnemyChange.Invoke(aliveEnemies);
        enemy.OnDeath -= HandleEnemyDeath;
        enemyPool.ReturnEnemy(enemy.gameObject);

        //if (aliveEnemies <= 0)
        //{
        //    OnWaveCleared?.Invoke();
        //}
    }
}

/* public class EnemySpawner : MonoBehaviour
{
    public event Action OnWaveCleared;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public Transform destinationPoint;
    float timeBetweenSpawn = 1.0f;
    int aliveEnemies = 0;

    [Header("References")]
    public EnemyPool enemyPool; // Ссылка на пул врагов

    private ResourcesSet rewardSettings;

    public void StartWaveSpawn(int enemyCount, ResourcesSet reward)
    {
        rewardSettings = reward;
        StartCoroutine(SpawnWave(enemyCount));
    }

    private IEnumerator SpawnWave(int enemyCount)
    {

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            aliveEnemies++;
            yield return new WaitForSeconds(timeBetweenSpawn);
            GameActions.EnemyChange.Invoke(aliveEnemies);
        }


    }

    private void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemy();
        enemy.transform.position = spawnPoint.position;
        enemy.GetComponent<EnemyController>().Init(rewardSettings, destinationPoint.position, 000000000000000000f);

        // Подписываемся на событие смерти
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        health.OnDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath(EnemyHealth enemy)
    {
        aliveEnemies--;
        GameActions.EnemyChange.Invoke(aliveEnemies);
        // Отписываемся от события, чтобы избежать утечек памяти
        enemy.OnDeath -= HandleEnemyDeath;

        // Возвращаем врага в пул
        enemyPool.ReturnEnemy(enemy.gameObject);

        // Если все враги убиты, вызываем событие
        if (aliveEnemies <= 0)
        {
            OnWaveCleared?.Invoke();
        }
    }
}*/