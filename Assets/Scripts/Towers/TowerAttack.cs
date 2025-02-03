using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] AudioClip attackSound;
    [SerializeField] Transform rotatePart;
    [SerializeField] Transform projectileSpawnOrigin;
    AudioSource attackSource;
    GameObject projectilePrefab;
    public List<EnemyHealth> enemies = new();
    Coroutine attackCoroutine;
    SphereCollider towerTrigger;
    TowerType towerType;
    int damage;
    float range;
    float recharge;

    public UnityEvent AttackEvent;
    public UnityEvent StopAttackEvent;

    public void InitOrUpdate(TowerConfig towerConfig)
    {
        attackSource = GetComponent<AudioSource>();
        towerTrigger = GetComponent<SphereCollider>();
        projectilePrefab = towerConfig.towerProjectilePrefab;
        damage = towerConfig.towerDamage;
        range = towerConfig.towerRange;
        recharge = towerConfig.towerRecharge;
        towerType = towerConfig.towerType;
        
        towerTrigger.radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyHealth>();
            enemies.Add(enemy);
            enemy.OnDeath += RemoveFromEnemiesList;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyHealth>();
            RemoveFromEnemiesList(enemy);
            enemy.OnDeath -= RemoveFromEnemiesList;
            
        }
    }

    private void RemoveFromEnemiesList(EnemyHealth enemy)
    {
        enemies.Remove(enemy);
    }

    private void Update()
    {
        if (attackCoroutine != null)
        {
            RotateToEnemy(enemies[0].transform);
            return;
        }

        if(enemies.Count > 0)
        {
            attackCoroutine = StartCoroutine(AttackEnemies());
        }
        else
        {
            attackCoroutine = null;
        }
    }

    IEnumerator AttackEnemies()
    {
        AttackEvent.Invoke();
        while (enemies.Count > 0)
        {
            Attack();
            yield return new WaitForSeconds(recharge);
        }
        StopAttackEvent.Invoke();
        attackCoroutine = null;
    }

    private void Attack()
    {
        switch (towerType)
        {
            case TowerType.Projectile:
                {
                    //enemies[0].TakeDamage(damage);
                    var prefab = Instantiate(projectilePrefab, projectileSpawnOrigin.position, Quaternion.identity);
                    PlayShot();
                    prefab.GetComponent<Projectile>().Init(enemies[0].transform, damage);
                }
                break;

            case TowerType.Multishot:
                {
                    foreach (var enemy in enemies)
                    {
                        //enemy.TakeDamage(damage);
                        var prefab = Instantiate(projectilePrefab, projectileSpawnOrigin.position, Quaternion.identity);
                        prefab.GetComponent<Projectile>().Init(enemy.transform, damage);
                    }
                }
                break;

            case TowerType.StaticShot:
                {
                    //foreach (var enemy in enemies)
                    for(int i = 0; i < enemies.Count; i++) 
                    {
                        try
                        {
                            if (enemies.Contains(enemies[i]))
                                enemies[i].TakeDamage(damage);
                            var prefab = Instantiate(projectilePrefab, enemies[i].transform);
                            //prefab.GetComponent<StaticProjectile>().Init(enemy.transform, damage);
                        }
                        catch(Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }
                }
                break;
        }
       
    }

    void RotateToEnemy(Transform enemy)
    {
        if (enemy != null)
        {
            Vector3 direction = enemy.position - transform.position; // Вектор к цели
            direction.y = 0; // Игнорируем наклон по Y

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    void PlayShot()
    {
        attackSource.PlayOneShot(attackSound);
    }
}
public enum TowerType { Projectile, Multishot, StaticShot }