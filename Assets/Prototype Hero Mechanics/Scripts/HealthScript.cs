using System;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] float maxHealth = 1;

    public HealthBar healthBar;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        ChangeHealth(currentHealth - damage, damage);
    }

    public void Heal(float healAmount)
    {
        ChangeHealth(currentHealth + healAmount, healAmount);
    }

    private void ChangeHealth(float newHealth, float deltaHealth)
    {
        if (InvalidValue(deltaHealth))
            throw new InvalidOperationException();

        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    private bool InvalidValue(float value)
    {
        return value < 0;
    }
}
