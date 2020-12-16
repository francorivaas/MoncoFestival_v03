using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gems = null;

    private Vector2 spawnZone;

    [SerializeField]
    private float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;

    private float randomX;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            randomX = Random.Range(-15, 15);

            spawnZone = new Vector2(randomX + transform.position.x, randomX + transform.position.y);

            Instantiate(gems, spawnZone, Quaternion.identity);
        }
    }
}
