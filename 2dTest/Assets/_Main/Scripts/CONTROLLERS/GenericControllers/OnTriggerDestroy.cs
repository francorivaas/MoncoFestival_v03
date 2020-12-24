using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject gemPickUpSound = null;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        gemPickUpSound.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GemsAmount.gemsAmount += 1;

            animator.SetTrigger("Plus");

            //gemPickUpSound.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        else
            gemPickUpSound.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("LOLARDO");
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("LOLARDO");
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("LOLARDO");
            Destroy(gameObject);
        }
    }
}
