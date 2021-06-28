using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadBomb : Item
{
    public override void Use()
    {
        Transform hero = GameObject.FindGameObjectWithTag("Player").transform;
        Machine nearestMachine = FindNearestMachine(hero);

        if (Vector2.Distance(hero.position, nearestMachine.transform.position) <= 6.5)
        {
            nearestMachine.OverloadMachine();
        }
        else
        {
            PrototypeHeroDemo heroScript = hero.GetComponent<PrototypeHeroDemo>();
            heroScript.TakeDamage(20);
        }

        Destroy(gameObject);
    }

    private Machine FindNearestMachine(Transform target)
    {
        Machine[] machines = FindObjectsOfType<Machine>();
        if (machines.Length == 0)
            throw new IndexOutOfRangeException();

        Machine nearestMachine = machines[0];
        float nearestDist = Vector2.Distance(target.position, nearestMachine.transform.position);

        for (int i = 1; i < machines.Length; i++)
        {
            float tempDist = Vector2.Distance(target.position, machines[i].transform.position);
            if (tempDist < nearestDist)
            {
                nearestDist = tempDist;
                nearestMachine = machines[i];
            }
        }

        return nearestMachine;
    }
}
