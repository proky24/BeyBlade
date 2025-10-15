using System;
using UnityEngine;
public class HealthModule : MonoBehaviour, IDamageable
{
    [Header("Souèasné hodnoty")]
    [SerializeField] private float health = 100.0f;
    [Header("Statické hodnoty")]
    [SerializeField] private float maxHealth = 100.0f;
    public event Action<float> onHealthChanged;
    public event Action onDeath;
    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public void Damage(float damage)
    {
        health -= damage;
        onHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    public void FullHeal()
    {
        health = maxHealth;
        onHealthChanged?.Invoke(health);
    }
    public void Heal(float healthAdded)
    {
        health += healthAdded;
        onHealthChanged?.Invoke(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void Die()
    {
        onDeath?.Invoke();
        Destroy(gameObject);
    }
}