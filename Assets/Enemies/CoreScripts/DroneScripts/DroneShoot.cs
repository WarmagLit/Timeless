using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShoot : MonoBehaviour
{
    [SerializeField] float fireRate = 1.5f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
