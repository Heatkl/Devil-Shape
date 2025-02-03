using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour, IProjectile
{
    public float speed;
    int damage;
    Transform enemy;
    public GameObject effect;
    MeshRenderer projectileRenderer;

    bool isMove = false;
    public void Activate()
    {
        isMove = true;
        projectileRenderer = GetComponent<MeshRenderer>();
    }

    public void Init(Transform enemy, int damage)
    {
        this.enemy = enemy;
        this.damage = damage;
        Activate();
    }

    public void SelfDestruction()
    {
        Destroy(gameObject, 0.1f);
        projectileRenderer.enabled = false;
        if (effect != null)
        {
            effect.SetActive(true);
        }
    }

    void MoveToEnemy()
    {
        if (enemy.gameObject.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
        }
        else
        {
            SelfDestruction();
        }
    }
    void Update()
    {
        if (isMove)
        {
            MoveToEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && isMove)
        {
            SelfDestruction();
            isMove = false;
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
