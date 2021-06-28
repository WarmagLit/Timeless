using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMachineBullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] int[] collisionLayers = { 6 };

    public int index = 0;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        foreach (int layer in collisionLayers)
        {
            if (hitInfo.gameObject.layer == layer)
            {
                Destroy(gameObject);

                PrototypeHeroDemo hero = hitInfo.transform.GetComponent<PrototypeHeroDemo>();
                if (hero != null)
                {
                    hero.TakeDamage(damage);
                }

                break;
            }
        }
    }
}
