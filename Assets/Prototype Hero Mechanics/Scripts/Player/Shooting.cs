using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum ShootingMode
{
    Bullet,
    Laser
}

public class Shooting : MonoBehaviour
{
    [SerializeField] float damage = 20;
    [SerializeField] float bulletCooldown = 0.3f;
    [SerializeField] float laserCooldown = 1.5f;

    [SerializeField] DurationImage modeUI;
    [SerializeField] Sprite laserSprite;
    [SerializeField] Sprite bulletSprite;

    public Transform firePoint;
    public LineRenderer lineRenderer;
    public LayerMask collisionMask;

    public GameObject bulletPrefab;

    private ShootingMode mode = ShootingMode.Bullet;
    private float lastBullet = -100;
    private float lastLaser = -100;

    private float maxCooldown = 3;
    private float currentCooldown;
    private bool onCooldown = false;

    private void Update()
    {
        if (onCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown > 0)
            {
                modeUI.SetCurrentDuration(currentCooldown / maxCooldown);
            }
            else
            {
                onCooldown = false;
                modeUI.SetCurrentDuration(0);
            }
        }
    }

    public void SwitchMode()
    {
        if (!onCooldown)
        {
            mode = mode == ShootingMode.Bullet ? ShootingMode.Laser : ShootingMode.Bullet;
            SwitchModeUI();
        }
    }

    public void Shoot()
    {
        if (mode == ShootingMode.Bullet)
        {
            ShootBullet();
        }
        else
        {
            StartCoroutine(ShootLaser());
        }
    }

    private void SwitchModeUI()
    {
        modeUI.GetComponent<Image>().sprite = mode == ShootingMode.Bullet ? bulletSprite : laserSprite;
        currentCooldown = maxCooldown;
        onCooldown = true;
    }

    private void ShootBullet()
    {
        if (Time.time >= (lastBullet + bulletCooldown))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            lastBullet = Time.time;
        } 
    }

    private IEnumerator ShootLaser()
    {
        if (Time.time >= (lastLaser + laserCooldown))
        {
            InitializeLaserLine();

            lineRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            lineRenderer.enabled = false;

            lastLaser = Time.time;
        } 
    }

    private void InitializeLaserLine()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - firePoint.position).normalized;
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, direction, float.MaxValue, collisionMask);

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
            SetShootLine(firePoint.position, firePoint.position + direction * 60);
        }
    }

    private void SetShootLine(Vector3 position1, Vector3 position2)
    {
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
    }
}
