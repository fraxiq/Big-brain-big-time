using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Numerics;

public class EnemyAIPrime : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDisrtance = 3f;

    public Transform enemyGFX;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);


    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);


    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    void FixedUpdate()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        UnityEngine.Vector2 direction = ((UnityEngine.Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        UnityEngine.Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = UnityEngine.Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDisrtance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new UnityEngine.Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        }
    }
}