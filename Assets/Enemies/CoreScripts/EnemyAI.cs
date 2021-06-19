using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDistance = 3f;

    public Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    public Seeker seeker;
    public Rigidbody2D rigidbody;
    public Transform target;

    private float changeRandomDirectionCooldown = .5f;
    private float lastDirectionChange = -100;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PrototypeHeroDemo>().transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        Fly();
    }

    private void Fly()
    {
        if (path == null) return;

        reachedEndOfPath = currentWaypoint >= path.vectorPath.Count - 3;
        if (reachedEndOfPath)
        {
            RandomFly();
            return;
        }

        PathFly();
    }

    private void RandomFly()
    {
        if (Time.time > (lastDirectionChange + changeRandomDirectionCooldown))
        {
            Vector2 direction, force;
            float[] randomRange = new float[] { Random.Range(-5f, -15f), Random.Range(5f, 15f) };

            direction = new Vector2(randomRange[Random.Range(0, 2)], randomRange[Random.Range(0, 2)]);
            force = direction * speed * Time.deltaTime;

            rigidbody.AddForce(force);
            lastDirectionChange = Time.time;
        }
    }

    private void PathFly()
    {
        Vector2 direction, force;

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidbody.position).normalized;
        force = direction * speed * Time.deltaTime;
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
