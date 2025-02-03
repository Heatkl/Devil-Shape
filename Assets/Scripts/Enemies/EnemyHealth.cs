using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public event Action<GameObject> OnDeath;
    private int currentHealth;
    private int onDieDamage;

    [SerializeField] private Slider healthSlider;

    public void Init(int health, int _onDieDamage)
    {
        currentHealth = health;
        onDieDamage = _onDieDamage;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<BaseHealth>();
        if (health != null)
        {
            health.TakeDamage(onDieDamage);
            OnDeath?.Invoke(gameObject);
        }
    }
}