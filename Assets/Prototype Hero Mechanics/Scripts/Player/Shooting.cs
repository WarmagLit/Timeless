using System.Collections;
using UnityEngine;

enum ShootingMode
{
    Bullet,
    Laser
}

public class Shooting : MonoBehaviour
{
    [SerializeField] float damage = 20;
    [SerializeField] float laserCooldown = 1;

    public Transform firePoint;
    public LineRenderer lineRenderer;
    public LayerMask collisionMask;

    public GameObject bulletPrefab;

    private ShootingMode mode = ShootingMode.Bullet;
    private float lastLaser = -100;

    public void SwitchMode()
    {
        mode = mode == ShootingMode.Bullet ? ShootingMode.Laser : ShootingMode.Bullet;
    }

    public void Shoot()
    {
        if (mode == ShootingMode.Bullet)
        {
            ShootBullet();
        }
        else
        {
            if (Time.time >= (lastLaser + laserCooldown))
            {
                StartCoroutine(ShootLaser());
                lastLaser = Time.time;
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private IEnumerator ShootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, float.MaxValue, collisionMask);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            SetShootLine(firePoint.position, hitInfo.point);
        }
        else
        {
            SetShootLine(firePoint.position, firePoint.position + firePoint.right * 16);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(.1f);

        lineRenderer.enabled = false;
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void SetShootLine(Vector3 position1, Vector3 position2)
    {
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
    }
}
