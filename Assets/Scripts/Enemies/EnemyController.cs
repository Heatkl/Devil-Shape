using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyConfig enemyConfig;

    [SerializeField] GameObject deathEffect;

    private EnemyMovement movement;
    private EnemyHealth health;
    private EnemyReward reward;

    private EnemyType enemyType;



    public void Init(EnemyReward rewardSettings, Vector3 destinationPoint, float speed)
    {
        movement = GetComponent<EnemyMovement>();
        health = GetComponent<EnemyHealth>();

        reward = new EnemyReward(rewardSettings);

        health.OnDeath += HandleDeath;

        movement.Init(destinationPoint, speed);
        health.Init(enemyConfig.maxHealth, 1);
    }

    private void HandleDeath(GameObject enemy)
    {
        //GameManager.Instance.AddResources(reward.magicEssence, reward.chromite, reward.uvarovite);
        Instantiate(deathEffect, transform.position, transform.rotation);
        
    }

    private void OnDestroy()
    {
        health.OnDeath -= HandleDeath;
    }


}
