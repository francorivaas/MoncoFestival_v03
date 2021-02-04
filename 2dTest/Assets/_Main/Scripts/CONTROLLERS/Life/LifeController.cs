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
    private GameObject monkeySound = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        currentLife = maxLife;
    }

    void Start()
    {
        //currentTimeToHeal = 0.0f;
        //canTakeDamage = true;
        monkeySound.gameObject.SetActive(false);
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
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyLifeController>() || gameObject.CompareTag("Enemy"))
        {
            monkeySound.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyLifeController>() || gameObject.CompareTag("Enemy"))
        {
            monkeySound.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;

        animator.SetTrigger("TakeDamage");

        OnGetDamage.Invoke(currentLife, damage);

        OnLifeChange.Invoke(currentLife);

        if (currentLife <= 0)
        {
            Die();
        }
    }

    
    public void Die()
    {
        SceneManager.LoadScene(sceneName);
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
