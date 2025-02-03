using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Tooltip("Тип противника, который влияет на его поведение")]
    public EnemyType type;
    [Tooltip("Экземпляр противника")]
    public GameObject enemyPrefab;
    [Tooltip("Здоровье противника (увеличивается от коэффициента)")]
    public int maxHealth;
    [Tooltip("Для Thief - количество монет, которые будет воровать каждую секунду. Для остальных - нанесенный урон при соприкосновении с базой (увеличивается от коэффициента)")]
    public int damageValue;
    [Tooltip("Скорость перемещения противника в м/с")]
    public float speed;
    [Tooltip("Количество награды за уничтожение юнита (увеличивается от коэффициента)")]
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
