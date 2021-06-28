using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 20f;
    [SerializeField] int[] collisionLayers = { 6, 3, 8};

    private Transform target;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PrototypeHeroDemo>().transform;
        AimedShot();
    }

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

    private void AimedShot()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rigidbody.velocity = direction * speed;
    }
}
