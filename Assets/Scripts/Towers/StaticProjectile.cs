using UnityEngine;

public class StaticProjectile : MonoBehaviour, IProjectile
{
    int damage;
    Transform enemy;

    public void Activate()
    {
        SelfDestruction();
    }

    public void Init(Transform enemy, int damage)
    {
        this.enemy = enemy;
        this.damage = damage;
        Activate();
    }

    public void SelfDestruction()
    {
        Destroy(gameObject, 1f); //Update to Pool later 
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
