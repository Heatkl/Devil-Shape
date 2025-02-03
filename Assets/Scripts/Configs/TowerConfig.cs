using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "Scriptable Objects/TowerConfig")]
public class TowerConfig : ScriptableObject
{
    public GameObject towerPrefab;
    public GameObject towerProjectilePrefab;

    public TowerType towerType;
    public int towerDamage;
    public float towerRange;
    public float towerRecharge;

    public ResourcesSet towerCost;
}
