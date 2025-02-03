using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/GameConfig")]
public class LevelConfig : ScriptableObject
{
    [Header("Common Settings")]

    [Tooltip("���������� ���� � ������. ��������� �������� ������� ��������� ���������.")]
    [Min(0)]
    public int numberOfWaves = 4;

    [Tooltip("����� � ��������, ������� �������� �� �������� �����, �� ������ ������ ��������� �����")]
    [Range(0f, 60f)]
    public float safeTimeAfterWave = 10f;
   
    [Tooltip("����������� ���������� ������� � ��������� �������, ��������� �� ����� (n * waveFactor)")]
    [Range(0f, 1f)]
    public float waveFactor = 0;

    [Header("Wave Settings")]
    [Tooltip("��������� ��� ������ ����� �� �������")]
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
    [Tooltip("������� �� ����������� �����")]
    [Min(0f)]
    public float waveReward;


    [Tooltip("��� ������ ������ � �����. Together - ��������� ������������ � ������, OneByOne - �������� �� �������, Random - ��������� ������, �� �� �������")]
    public EnemySpawnType spawnType;

    [Header("Enemies in Wave")]
    public EnemyWaveSettings[] enemies;

    
}

[System.Serializable]
public class EnemyWaveSettings
{
    [Tooltip("��������� ������� �������, ������� ����� � �����")]
    public EnemyConfig enemyConfig;

    [Tooltip("����� � �������� ����� ������� ������ ����� ����")]
    [Range (0, 10f)]
    public float timeBetweenEnemiesSpawn;

    [Tooltip("���������� �������� ����� ���� � ����� (������ �� ������������)")]
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