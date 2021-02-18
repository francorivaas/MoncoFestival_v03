﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    [SerializeField] 
    private float maxLife = 2.0f;

    [SerializeField] 
    private float currentLife = 0.0f;

    public EnemyCounter enemyCounter;

    private void Start()
    {
        currentLife = maxLife;
    }

    public void TakePlayerDamage(float damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            UIenemiesCounter.points++;
            EnemyCounter.enemiesKilled++;

            Destroy(gameObject);
        }
    }
    
}
