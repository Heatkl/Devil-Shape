using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelConfig levelConfig;
    EnemySpawner enemySpawner;
    GameManager gameManager;

    public int lastWave;
    public int currentWave = 0;
    public float safeTimeAfterWave;
    public float waveFactor;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        enemySpawner.OnWaveCleared += FinishWave;

        levelConfig.GetLevelInfo(out lastWave, out safeTimeAfterWave, out waveFactor);

        StartCoroutine(WaitUntilWaveSpawn());
        
    }

    private void OnEnable()
    {
        //enemySpawner.OnWaveCleared += FinishWave;
    }

    private void OnDisable()
    {
        enemySpawner.OnWaveCleared -= FinishWave;
    }
    void Update()
    {
        
    }

    void FinishWave()
    {
        Debug.LogWarning("WaveCleared");
        StartCoroutine(WaitUntilWaveSpawn());
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
        enemySpawner.StartWaveSpawn(levelConfig.waves[currentWave-1], levelConfig.waveFactor +1);//levelConfig.waves[currentWave].enemies[0].waveEnemiesCount, levelConfig.waves[currentWave].enemies[0].enemyConfig.rewardPerUnit);
    }

    IEnumerator WaitUntilWaveSpawn()
    {
        yield return new WaitForSeconds(safeTimeAfterWave);
        currentWave++;
        gameManager.ChangeWaves(currentWave);
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
