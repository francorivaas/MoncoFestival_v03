﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnemies : MonoBehaviour
{
    [SerializeField]
    private float timeToSummon = 1.0f;

    [SerializeField]
    private float currentTimeToSummon = 0.0f;

    [SerializeField]
    private GameObject enemy = null;

    [SerializeField]
    private int enemiesAmount = 0;

    [SerializeField]
    private float timeToResume = 3.0f;

    private float currentTimeToResume = 0.0f;

    [SerializeField]
    private bool canInstantiate = false;

    [SerializeField]
    private Transform summonPoint = null;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        canInstantiate = true;

        currentTimeToSummon = timeToSummon;
    }

    private void Update()
    {
        currentTimeToSummon += Time.deltaTime;

        if (currentTimeToSummon >= timeToSummon && canInstantiate)
        {
            Instantiate(enemy, summonPoint.position, Quaternion.identity);
            animator.SetTrigger("Invoke");

            currentTimeToSummon = 0.0f;

            enemiesAmount ++;

            if (enemiesAmount >= 3)
                canInstantiate = false;
        }

        else if (!canInstantiate)
        {
            currentTimeToResume += Time.deltaTime;

            if (currentTimeToSummon >= timeToResume)
            {
                canInstantiate = true;
                enemiesAmount = 0;
            }
        }
    }
}
