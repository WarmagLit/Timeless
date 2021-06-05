using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public LayerMask collisionMask;

    public IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, float.MaxValue, collisionMask);

        if (hitInfo)
        {
            //Enemy damaging logic
            SetShootLine(firePoint.position, hitInfo.point);
        }
        else
        {
            SetShootLine(firePoint.position, firePoint.position + firePoint.right * 16);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.05f);

        lineRenderer.enabled = false;
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void SetShootLine(Vector3 position1, Vector3 position2)
    {
        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
    }
}
