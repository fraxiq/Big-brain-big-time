using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public float dashRate = 2f;
    float nextDash = 0f;



    private int direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dashTime = startDashTime;

    }



    void playerDashLeft()
    {
        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
        }
        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {

            if (direction == 1)
            {
                rb.velocity = Vector2.left * dashSpeed;
            }
        }
    }
    void playerDashRight()
    {
          if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
        {
            direction = 2;
        }
        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
           
             if (direction == 2)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
        }
    }
    void Update()
    {
        if (Time.time >= nextDash)
        {
            if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow))
            {
                playerDashRight();
                nextDash = Time.time + 1f / dashRate;
            }
            if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow))
            {
                playerDashLeft();
                nextDash = Time.time + 1f / dashRate;
            }


        }
    }
}
