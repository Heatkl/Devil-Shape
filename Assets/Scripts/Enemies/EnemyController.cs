using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyConfig enemyConfig;

    [SerializeField] GameObject deathEffect;

    private GameManager gameManager;
    private EnemyMovement movement;
    private EnemyHealth health;
    private ResourcesSet reward;

    private EnemyType enemyType;



    public void Init(ResourcesSet rewardSettings, Vector3 destinationPoint, float speed)
    {
        movement = GetComponent<EnemyMovement>();
        health = GetComponent<EnemyHealth>();
        gameManager = FindAnyObjectByType<GameManager>();

        reward = new ResourcesSet(rewardSettings);

        health.OnDeath += HandleDeath;

        movement.Init(destinationPoint, speed);
        health.Init(enemyConfig.maxHealth, 1);
    }

    private void HandleDeath(EnemyHealth enemy)
    {
        gameManager.AddResources(reward);
        Instantiate(deathEffect, transform.position, transform.rotation);
        
    }

    private void OnDestroy()
    {
        health.OnDeath -= HandleDeath;
    }


}
