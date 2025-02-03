using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static event Action OnWaveCleared;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public Transform destinationPoint;
    float timeBetweenSpawn = 1.0f;
    int aliveEnemies = 0;

    [Header("References")]
    public EnemyPool enemyPool; // ������ �� ��� ������

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

        // ������������� �� ������� ������
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        health.OnDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath(EnemyHealth enemy)
    {
        aliveEnemies--;
        GameActions.EnemyChange.Invoke(aliveEnemies);
        // ������������ �� �������, ����� �������� ������ ������
        enemy.OnDeath -= HandleEnemyDeath;

        // ���������� ����� � ���
        enemyPool.ReturnEnemy(enemy.gameObject);

        // ���� ��� ����� �����, �������� �������
        if (aliveEnemies <= 0)
        {
            OnWaveCleared?.Invoke();
        }
    }
}