using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 20f;
    public Rigidbody2D rigidbody;

    private int collisionLayer = 3;

    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer == collisionLayer)
        {
            Destroy(gameObject);

            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
