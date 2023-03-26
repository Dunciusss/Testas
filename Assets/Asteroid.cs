using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    public int numSmallerAsteroids;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), -1) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 tempVelocity = rb.velocity;
            rb.velocity = otherRb.velocity;
            otherRb.velocity = tempVelocity;
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            for (int i = 0; i < numSmallerAsteroids; i++)
            {
                GameObject smallerAsteroid = Instantiate(gameObject, transform.position, Quaternion.identity);
                smallerAsteroid.transform.localScale /= 2;
                smallerAsteroid.AddComponent<Rigidbody2D>();
                smallerAsteroid.AddComponent<CircleCollider2D>();
                smallerAsteroid.AddComponent<Asteroid>();
                smallerAsteroid.GetComponent<Asteroid>().numSmallerAsteroids = numSmallerAsteroids - 1;
            }

            Destroy(gameObject);
        }
    }

}