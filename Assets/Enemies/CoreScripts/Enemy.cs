using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected HealthScript healthScript;

    private bool alive = true;

    virtual protected void Start()
    {
        healthScript = GetComponent<HealthScript>();
    }

    virtual protected void Update()
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
        if (!healthScript.Alive() && alive)
        {
            Die();
            alive = false;
        }
    }

    virtual protected void Die()
    {
        Destroy(gameObject);
    }
}
