using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] 
    private float damage = 1f;
    
    public float damageRate = 15f;
    
    private float nextTimeToDamage = 0.0f;

    private Collider2D col;

    private float timeToShowCollider = 2.0f;
    private float currentTimeToShowCollider = 0.0f;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        col.enabled = false;
    }

    private void Update()
    {
        timeToShowCollider -= Time.deltaTime;

        if (timeToShowCollider <= currentTimeToShowCollider)
        {
            Debug.Log("el col está del orto mal y en pija");
            col.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LifeController player = other.GetComponent<LifeController>();
        
        if (player != null && Time.time >= nextTimeToDamage)
        { 
            nextTimeToDamage = Time.time + 1f / damageRate;
            
            player.TakeDamage(damage);
        }
    }    
}
