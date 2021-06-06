using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvents : MonoBehaviour
{
    public void DamageEvent(PrototypeHeroDemo player)
    {
        player.TakeDamage(0.1f);
    }

    public void HealEvent(PrototypeHeroDemo player)
    {
        player.Heal(0.1f);
    }
}
