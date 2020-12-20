﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gems = null;

    [SerializeField]
    private float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;

    private float randomX;
    private float randomY;

    private Vector2 spawnZone;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            randomX = Random.Range(-5, 5);
            randomY = Random.Range(0, -5);

            spawnZone = new Vector2(randomX - transform.position.x, randomY + transform.position.y);

            Instantiate(gems, spawnZone, Quaternion.identity);
        }
    }
}
