using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public string Name;

    [SerializeField] 
    private float maxLife = 100f;
    public float currentLife;
    private float lifePlus = 100.0f;

    public UnityEvent OnDeath = new UnityEvent();

    //DieEvent and Animation
    [SerializeField]
    private float timeToDie = 1.5f;
    private float currentTimeToDie = 0.0f;

    public bool isDying = false;

    /*
    [SerializeField] 
    private float currentTimeToHeal;

    public bool canHeal = true;
    public bool canTakeDamage = true;


    private float healPowerUp = 10.0f;
    private float timeToHeal = 10.0f;
    */

    [SerializeField] 
    private string sceneName = null;

    public Action<float, float> OnGetDamage;
    public Action<float> OnLifeChange;

    [SerializeField]
    private EnemyCounter enemyCounter;

    private Animator animator = null;

    [SerializeField]
    private AudioClip healthPowerUp;

    private AudioSource audioSource;

    [SerializeField]
    private Animator animator_Lifebar;

    [SerializeField]
    private AudioClip monkeySound;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        currentLife = maxLife;
    }

    void Start()
    {
        //currentTimeToHeal = 0.0f;
        //canTakeDamage = true;
        isDying = false;
    }

    private void Update()
    {
        //Heal Settings

        if (currentLife < maxLife && enemyCounter.canRecover)
        {
            enemyCounter.canRecover = false;

            Heal();
        }
            
        /*currentTimeToHeal += Time.deltaTime;

        if(currentTimeToHeal >= timeToHeal)
        {
            canHeal = false;
            //Heal();
        }
        */
    }

    public void Heal()
    {
        currentLife = maxLife;
        OnLifeChange.Invoke(currentLife);

        audioSource.clip = healthPowerUp;
        audioSource.Play();

        Debug.Log("porque no hay sonedeetoo");

        animator_Lifebar.SetTrigger("LifebarFulll");
    }


    public void TakeDamage(float damage)
    {
        if (!isDying)
        {
            currentLife -= damage;

            audioSource.clip = monkeySound;
            audioSource.Play();

            animator.SetTrigger("TakeDamage");

            OnGetDamage.Invoke(currentLife, damage);

            OnLifeChange.Invoke(currentLife); 
        }

        if (currentLife <= 0)
        {
            Die();
        }
    }

    
    public void Die()
    {
        currentTimeToDie += Time.deltaTime;

        isDying = true;

        Debug.Log(currentTimeToDie);

        if (currentTimeToDie >= timeToDie)
        {
            isDying = false;

            GemsAmount.gemsAmount = 0;

            SceneManager.LoadScene(sceneName);
        }
    }

    /*
    public void HealthRecover()
    {
        enemyCounter.canRecover = false;
        currentLife += lifePlus;
    }
    */

    public float GetCurrentLife()
    {
        return currentLife;
    }

    public float GetMaxLife()
    {
        return maxLife;
    }

    public float GetLifePercentage()
    {
        return currentLife / maxLife;
    }
}
