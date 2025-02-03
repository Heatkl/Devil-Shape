using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] UIManager uiManager;
    [SerializeField] ResourcesSet resourcesSet;

    int totalEnemies = 0;
    int currentWave = 0;

    private void OnEnable()
    {
        GameActions.EnemyChange += ChangeEnemies;
    }

    private void OnDisable()
    {
        GameActions.EnemyChange -= ChangeEnemies;
    }

    private void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        uiManager.UpdateTopPanel(totalEnemies, currentWave, resourcesSet);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void AddResources(ResourcesSet set)
    {
        resourcesSet.Add(set);
        uiManager.UpdateResources(resourcesSet);
    }

    public bool CheckExistsResources(ResourcesSet set)
    {
        if (resourcesSet.IsAvaliable(set))
        {
            resourcesSet.Remove(set);
            uiManager.UpdateResources(resourcesSet);
            return true;
        }
        else
        {
            return false;   
        }
    }

    void ChangeEnemies(int enemies)
    {
        totalEnemies = enemies;
        uiManager.UpdateEnemies(totalEnemies);
    }

    void ChangeWaves(int waves)
    {
        currentWave = waves;
        uiManager.UpdateWaves(currentWave);
    }
}
