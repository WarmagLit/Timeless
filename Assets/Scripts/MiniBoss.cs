using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{
    public GameObject bossTeleport;

    protected override void Die()
    {
        animator.SetBool("isDead", true);
        bossTeleport.SetActive(true);
    }
}
