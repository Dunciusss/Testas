using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 7;
    public Rigidbody2D rb;

    float dashSpeed = 25;
    float dashTime;
    float startDashTime = 0.2f;
    int direction;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        dashTime = startDashTime;
        firePoint = transform.Find("FirePoint");
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0)
        {
            MoveRight();
        }

        if (x < 0)
        {
            MoveLeft();
        }

        if (x == 0)
        {
            Stop();
        }
        if (y > 0)
        {
            MoveUp();
        }
        if (y < 0)
        {
            MoveDown();
        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (x < 0)
                {
                    direction = 1;
                }
                else if (x > 0)
                {
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }

            }

        }
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

    }

    void MoveRight()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }
    void MoveUp()
    {
        rb.velocity = new Vector2(0, speed);
    }
    void MoveDown()
    {
        rb.velocity = new Vector2(0, -speed);
    }
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bullet.GetComponent<Bullet>().speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Deleter")
        {
            
        }
        else
        {

        Time.timeScale = 0f;
        }
    }
}
