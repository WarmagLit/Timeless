using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMachineBullet : MonoBehaviour
{
    [SerializeField] float damage = 5;

    public int index = 0;

    private int collisionLayer = 6;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer == collisionLayer)
        {
            Destroy(gameObject);

            PrototypeHeroDemo hero = hitInfo.transform.GetComponent<PrototypeHeroDemo>();
            if (hero != null)
            {
                hero.TakeDamage(damage);
            }
        }
    }
}
