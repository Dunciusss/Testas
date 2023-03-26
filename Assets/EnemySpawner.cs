using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject obj;
    Vector2 location;
    float randomx;
    public float spawnrate;
    float nextspawn = 0f;

    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            randomx = Random.Range(-9f, 9f);
            location = new Vector2(randomx, transform.position.y);
            Instantiate(obj, location, Quaternion.identity);
        }

    }
}
