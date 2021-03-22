using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    private float maxLife = 4.0f;
    private float currentLife = 0.0f;
    public EnemyCounter enemyCounter;
    private Animator animator = null;
    public static bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentLife = maxLife;
        isDead = false;
    }

    public void TakePlayerDamage(float damage)
    {
        currentLife -= damage;

        if (currentLife <= 2f)
            animator.SetBool("IsDying", true);

        if (currentLife <= 0)
        {
            isDead = true;
            UIenemiesCounter.points++;
            EnemyCounter.enemiesKilled++;

            Destroy(gameObject, 0.6f);
        }
    }
    
}
