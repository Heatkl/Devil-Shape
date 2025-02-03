using System;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public event Action<GameObject> OnDeath;
    private int currentHealth;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        Init(100);
    }
    public void Init(int health)
    {
        currentHealth = health;
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
}
