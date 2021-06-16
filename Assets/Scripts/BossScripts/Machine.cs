using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : Enemy
{
    protected bool destructed = false;
    private bool overloaded = true;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (!overloaded)
        {
            healthScript.SelfRegenerate();
        }
        else
        {
            healthScript.SelfDamage();
        }
    }

    protected override void Die()
    {
        destructed = true;
    }
}
