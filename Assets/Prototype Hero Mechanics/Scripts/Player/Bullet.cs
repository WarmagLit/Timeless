using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 20f;

    private Vector2 mousePosition;
    private Rigidbody2D rigidbody;

    public Animator animator;
    private int[] collisionLayers = {3, 7};

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = (mousePosition - (Vector2)transform.position).normalized * speed;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer == collisionLayers[0] || hitInfo.gameObject.layer == collisionLayers[1])
        {
            yield return new WaitForSeconds(0.01f);
            rigidbody.velocity = new Vector2(0, 0);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            Machine machine = hitInfo.transform.GetComponent<Machine>();
            if (enemy != null && machine == null)
            {
                enemy.TakeDamage(damage);    
            }
            animator.SetTrigger("Crush");
            yield return new WaitForSeconds(0.11f);
            Destroy(gameObject);
        }
    }

    public void Deactivation() {
        Destroy(gameObject);
    }
}
