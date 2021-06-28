using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    public GameObject bombPrefab;

    public bool bomb = true;

    protected override void Die()
    {
        
        base.Die();
        StartCoroutine(WaitForDie());
        
    }

    private IEnumerator WaitForDie() {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        if (bomb) 
        {
            Instantiate(bombPrefab, transform.position, transform.rotation);
        }
    }
}
