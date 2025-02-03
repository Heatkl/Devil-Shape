using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    [SerializeField] GameObject upgradeButtons;
    [SerializeField] GameObject towerButtons;

    TowerConfig config;
    Transform targetSpawnPosition;

    public void SetBuildingUI(Transform spawnPosition)
    {
        targetSpawnPosition = spawnPosition;
        upgradeButtons.SetActive(false);
        towerButtons.SetActive(true);
    }

    public void SetUpdateUI()
    {
        upgradeButtons.SetActive(true);
        towerButtons.SetActive(false);
    }
}
