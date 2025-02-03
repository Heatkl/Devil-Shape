using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    public void SpawnTower(TowerConfig type, Transform spawnTransform)
    {
        GameObject towerPrefab = type.towerPrefab;
        if (towerPrefab != null)
        {
            var tower = Instantiate(towerPrefab, spawnTransform.position, Quaternion.identity);
            tower.GetComponent<TowerAttack>().InitOrUpdate(type);
        }
    }

   
}

