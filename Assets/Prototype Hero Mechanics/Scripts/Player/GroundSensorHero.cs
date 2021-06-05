using UnityEngine;
using System.Collections;

public class GroundSensorHero : MonoBehaviour {

    public LayerMask collisionMask;

    private float disableTimer;

    public bool State()
    {
        if (disableTimer > 0)
            return false;
        return Grounded();
    }

    private bool Grounded()
    {
        float leftPosition = transform.position.x - 0.32f;
        float rightPosition = transform.position.x + 0.32f;
        float rayCastDownDistance = 0.1f;

        return GroundUnderPosition(leftPosition, rayCastDownDistance) || GroundUnderPosition(rightPosition, rayCastDownDistance);
    }

    private bool GroundUnderPosition(float xPosition, float rayCastDownDistance)
    {
        Vector2 rayCastDown = new Vector2(xPosition, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayCastDown, Vector2.down, rayCastDownDistance, collisionMask);

        return hit.collider != null;
    }

    void Update()
    {
        disableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        disableTimer = duration;
    }
}
