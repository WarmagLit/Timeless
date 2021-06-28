using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvents : MonoBehaviour
{
    private PrototypeHeroDemo player;

    private void Start()
    {
        player = FindObjectOfType<PrototypeHeroDemo>();
    }

    public void DamageEvent(float damagePerFrame)
    {
        player.TakeDamage(damagePerFrame);
    }

    public void HealEvent(float healPerFrame)
    {
        player.Heal(healPerFrame);
    }
}
