using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Numerics;


public class BossAIPrime : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDisrtance = 3f;
    public float aggrorange = 1f;
    private UnityEngine.Vector3 playerPos;
    private UnityEngine.Vector3 enemyPos;
    public GameObject Enemy;
    float horizontalMove = 0f;




    public Transform enemyGFX;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    public Animator anim;

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
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        playerPos = transform.position;
        enemyPos = Enemy.transform.position;
        float playerX = playerPos.x;
        float enemyX = enemyPos.x;
        if (Mathf.Abs(playerX - enemyX) >= aggrorange)
        {

            return;

        }
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
        if (horizontalMove >= 0.01)
        {
            anim.Play("running");
        }
    }
}
