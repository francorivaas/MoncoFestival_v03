using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject gemPickUpSound = null;

    private void Start()
    {
        gemPickUpSound.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GemsAmount.gemsAmount += 1;

            gemPickUpSound.gameObject.SetActive(true);

            Destroy(gameObject);
        }

        else if (collision.CompareTag("Ground"))
        {
            gemPickUpSound.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            gemPickUpSound.gameObject.SetActive(false);
        }
    }
}
