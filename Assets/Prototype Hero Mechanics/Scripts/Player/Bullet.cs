using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 20f;

    private Vector2 mousePosition;
    private Rigidbody2D rigidbody;
    private int collisionLayer = 3;

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = (mousePosition - (Vector2)transform.position).normalized * speed;
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
