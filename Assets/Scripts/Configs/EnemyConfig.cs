using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Tooltip("��� ����������, ������� ������ �� ��� ���������")]
    public EnemyType type;
    [Tooltip("��������� ����������")]
    public GameObject enemyPrefab;
    [Tooltip("�������� ���������� (������������� �� ������������)")]
    public int maxHealth;
    [Tooltip("��� Thief - ���������� �����, ������� ����� �������� ������ �������. ��� ��������� - ���������� ���� ��� ��������������� � ����� (������������� �� ������������)")]
    public int damageValue;
    [Tooltip("�������� ����������� ���������� � �/�")]
    public float speed;
    [Tooltip("���������� ������� �� ����������� ����� (������������� �� ������������)")]
    public EnemyReward rewardPerUnit; 
}

public enum EnemyType
{
    Simple,
    Speedrunner,
    Damager,
    Tank,
    Fly,
    Mage,
    Thief

}
