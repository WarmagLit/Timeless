using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    public GameObject bombPrefab;

    protected override void Die()
    {
        base.Die();
        Instantiate(bombPrefab, transform.position, transform.rotation);
    }
}
