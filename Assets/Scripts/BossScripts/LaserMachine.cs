using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMachine : Machine
{
    [SerializeField] float damage = 0;
    [SerializeField] float rotationSpeed = 1;

    public Transform target;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public LayerMask collisionMask;

    protected override void Update()
    {
        base.Update();
        if (destructed)
        {
            ShootLaser();
        }
    }

    protected override void Die()
    {
        base.Die();
    }

    private void ShootLaser()
    {
        Vector2 direction = (target.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        firePoint.rotation = Quaternion.Slerp(firePoint.rotation, rotation, rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, float.MaxValue, collisionMask);

        if (hitInfo)
        {
            SetShootLine(firePoint.position, hitInfo.point);

            PrototypeHeroDemo hero = hitInfo.transform.GetComponent<PrototypeHeroDemo>();
            if (hero != null)
            {
                hero.TakeDamage(damage);
            }
        }
        else
        {
            SetShootLine(firePoint.position, firePoint.right * 60);
        }
    }

    private void SetShootLine(Vector3 position1, Vector3 position2)
    {
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
    }
}
