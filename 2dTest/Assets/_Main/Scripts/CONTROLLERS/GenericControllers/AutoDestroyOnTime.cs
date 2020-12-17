using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyOnTime : MonoBehaviour
{
    [SerializeField]
    private float maxLife = 5.0f;

    [SerializeField]
    private float currentLife = 0.0f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        currentLife += Time.deltaTime;

        if (currentLife >= maxLife)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Colliders")) animator.SetTrigger("Destroy");

    }
}
