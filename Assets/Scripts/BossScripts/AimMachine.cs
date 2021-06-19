using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMachine : Machine
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float shootCooldown = 15;
    [SerializeField] float timeBetweenShots = .1f;
    [SerializeField] float shotsCount = 20;

    public Transform target;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float lastShootSeries = -100;

    protected override void Update()
    {
        base.Update();
        if (destructed && Time.time >= (lastShootSeries + shootCooldown))
        {
            ShootSeries();
        }
    }

    private void ShootSeries()
    {
        for (int i = 0; i < shotsCount; i++)
        {
            StartCoroutine(InstantiateBullet(i));
        }
        lastShootSeries = Time.time;
    }

    private IEnumerator InstantiateBullet(int index)
    {
        yield return new WaitForSeconds(index * timeBetweenShots);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 direction = (target.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    protected override void Die()
    {
        base.Die();
        FindObjectOfType<FirstPhase>().AddDestructedMachine(this);
    }
}
