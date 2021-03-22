using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float damage = 2f;
    private float lifeTime = 2f;
    private float currentLifeTime = 0.0f;
    [SerializeField] private GameObject VFX = null;
    [SerializeField] private GameObject getShotSound = null;

    private void Start()
    {
        getShotSound.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position += transform.right * (speed * Time.deltaTime); 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyLifeController enemy = other.GetComponent<EnemyLifeController>();

        if (enemy != null)
        {
            //Sound settings
            getShotSound.gameObject.SetActive(true);

            //VFX settings
            Instantiate(VFX, transform.position, Quaternion.identity);

            //Events
            enemy.TakePlayerDamage(damage);
            //Destroy(this.gameObject);
        }
        else
            getShotSound.gameObject.SetActive(false);
    }
}
