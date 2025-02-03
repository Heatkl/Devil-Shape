using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/GameConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Common Settings")]

    [Tooltip("Количество волн в уровне. ИЗМЕНЕНИЕ ЗНАЧЕНИЯ СБРОСИТ ОСТАЛЬНЫЕ НАСТРОЙКИ.")]
    [Min(0)]
    public int numberOfWaves = 4;

    [Tooltip("Время в секундах, которое проходит от зачистки волны, до начала спавна следующей волны")]
    [Range(0f, 60f)]
    public float safeTimeAfterWave = 10f;
   
    [Tooltip("Коэффициент увеличения награды и сложности монстра, зависящий от волны (n * waveFactor)")]
    [Range(0f, 1f)]
    public float waveFactor = 0;

    [Header("Wave Settings")]
    [Tooltip("Настройки для каждой волны по порядку")]
    public WaveSettings[] waves;


    public void GetLevelInfo(out int _numberOfWaves, out float _safeTime, out float _waveFactor)
    {
        _numberOfWaves = numberOfWaves; _safeTime = safeTimeAfterWave; _waveFactor = waveFactor;
    }

    private void OnValidate()
    {
        if (waves == null || waves.Length != numberOfWaves)
        waves = new WaveSettings[numberOfWaves];
    }
}

[System.Serializable]
public class WaveSettings
{
    [Tooltip("Награда за прохождение волны")]
    [Min(0f)]
    public float waveReward;


    [Tooltip("Тип спавна врагов в волне. Together - спавнятся одновременно и вместе, OneByOne - группами по очереди, Random - спавнятся вместе, но по очереди")]
    public EnemySpawnType spawnType;

    [Header("Enemies in Wave")]
    public EnemyWaveSettings[] enemies;

    
}

[System.Serializable]
public class EnemyWaveSettings
{
    [Tooltip("Экземпляр префаба монстра, который будет в волне")]
    public EnemyConfig enemyConfig;

    [Tooltip("Время в секундах между спавном врагов этого вида")]
    [Range (0, 10f)]
    public float timeBetweenEnemiesSpawn;

    [Tooltip("Количество монстров этого вида в волне (влияет на длительность)")]
    [Range(0, 100)]
    public int waveEnemiesCount;
}

[System.Serializable]
public enum EnemySpawnType
{
    Together,
    OneByOne,
    Random
}