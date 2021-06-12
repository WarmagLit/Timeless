using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthScript healthScript;

    void Start()
    {
        healthScript = GetComponent<HealthScript>();
    }

    void Update()
    {
        CheckAlive();
    }

    public void TakeDamage(float damage)
    {
        healthScript.TakeDamage(damage);
    }

    public void Heal(float healAmount)
    {
        healthScript.Heal(healAmount);
    }

    public void CheckAlive()
    {
        if (!healthScript.Alive())
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
