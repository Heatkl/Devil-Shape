using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelConfig levelConfig;
    EnemySpawner enemySpawner;

    public int lastWave;
    public int currentWave = 0;
    public float safeTimeAfterWave;
    public float waveFactor;
    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        
        levelConfig.GetLevelInfo(out lastWave, out safeTimeAfterWave, out waveFactor);

        StartCoroutine(WaitUntilWaveSpawn());
        
    }

    void Update()
    {
        
    }

    void FinishLevel()
    {

    }

    void LoseLevel()
    {

    }

    void WinLevel()
    {
        GameActions.IncreaseScore.Invoke(2);
    }

    void StartWave()
    {
        enemySpawner.StartWaveSpawn(levelConfig.waves[currentWave].enemies[0].waveEnemiesCount, levelConfig.waves[currentWave].enemies[0].enemyConfig.rewardPerUnit);
    }

    IEnumerator WaitUntilWaveSpawn()
    {
        yield return new WaitForSeconds(safeTimeAfterWave);
        currentWave++;
        if (currentWave <= lastWave)
        {
            StartWave();
        }
        else
        {
            //Win
        }
    }
}
