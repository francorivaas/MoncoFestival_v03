using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

    void Start()
    {
        //currentTimeToHeal = 0.0f;
        //canTakeDamage = true;
        currentLife = maxLife;
    }

    private void Update()
    {
        if (currentLife < maxLife && enemyCounter.canRecover)
        {
            HealthRecover();
        }
            


        /*currentTimeToHeal += Time.deltaTime;

        if(currentTimeToHeal >= timeToHeal)
        {
            canHeal = false;
            //Heal();
        }
        */
    }

    /*
    public void Heal()
    {
        canHeal = false;

        if(Input.GetKeyDown(KeyCode.H))
        {
            OnLifeChange.Invoke(currentLife);
            currentTimeToHeal = 0.0f;
        }
    }
    */

    public void TakeDamage(float damage)
    {
        //if(canTakeDamage)
        currentLife -= damage;

        OnGetDamage.Invoke(currentLife, damage);

        OnLifeChange.Invoke(currentLife);

        if (currentLife <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void HealthRecover()
    {
        enemyCounter.canRecover = false;
        currentLife += lifePlus;
    }

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
