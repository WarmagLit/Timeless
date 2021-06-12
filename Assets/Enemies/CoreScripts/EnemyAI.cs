using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rigidbody;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        if (path == null) return;

        reachedEndOfPath = currentWaypoint >= path.vectorPath.Count;
        if (reachedEndOfPath) return;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidbody.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rigidbody.AddForce(force);

        float distance = Vector2.Distance(rigidbody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rigidbody.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
