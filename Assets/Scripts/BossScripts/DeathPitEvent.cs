using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPitEvent : MonoBehaviour
{
    [SerializeField] PrototypeHeroDemo player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(float.MaxValue);
    }
}
