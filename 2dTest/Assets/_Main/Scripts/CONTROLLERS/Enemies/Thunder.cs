using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private float maxTime = 2.0f;
    private float currentTime = 0.0f;

    private LifeController monco;

    private float damage = 30.0f;

    private void Update()
    {
        maxTime -= Time.deltaTime;

        if (maxTime <= currentTime)
        {
            gameObject.SetActive(false);

            currentTime = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (monco = collision.GetComponent<LifeController>())    
        {
            if (monco != null)
            {
                monco.TakeDamage(damage);
            }
        }
    }
}
