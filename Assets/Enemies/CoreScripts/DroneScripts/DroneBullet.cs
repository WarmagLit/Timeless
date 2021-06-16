using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 20f;

    private Transform target;
    private Rigidbody2D rigidbody;
    private int collisionLayer = 6;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PrototypeHeroDemo>().transform;
        AimedShot();
    }

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

    private void AimedShot()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rigidbody.velocity = direction * speed;
    }
}
