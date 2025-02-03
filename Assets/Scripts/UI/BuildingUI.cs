using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;
    [SerializeField] GameObject upgradeButtons;
    [SerializeField] GameObject towerButtons;

    [SerializeField] private TowerSpawner towerSpawner;
    [SerializeField] private GameManager gameManager;

    TowerConfig config;
    Transform targetSpawnPosition;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void SetBuildingUI(Transform spawnPosition)
    {
        targetSpawnPosition = spawnPosition;
        buttonPanel.SetActive(true);
        upgradeButtons.SetActive(false);
        towerButtons.SetActive(true);
    }

    public void SetUpdateUI()
    {
        buttonPanel.SetActive(true);
        upgradeButtons.SetActive(true);
        towerButtons.SetActive(false);
    }

    public void SpawnTower(TowerConfig towerConfig )
    {
        if (gameManager.CheckExistsResources(towerConfig.towerCost))
        {
            towerSpawner.SpawnTower(towerConfig, targetSpawnPosition);
            targetSpawnPosition.gameObject.SetActive(false);
        }
        
        //gameObject.SetActive(false); // Отключаем кнопку после спавна
    }
}
