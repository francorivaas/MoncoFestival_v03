using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    private AudioClip gemPickUpSound = null;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GemsAmount.gemsAmount += 1;

            audioSource.clip = gemPickUpSound;
            audioSource.Play();

            Destroy(gameObject, 0.5f);
        }
    }
}
