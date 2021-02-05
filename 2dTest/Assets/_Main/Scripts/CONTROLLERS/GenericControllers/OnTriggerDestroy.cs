using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour
{
    [SerializeField]
    private AudioClip gemPickUpSound = null;

    private AudioSource audioSource;
    private SpriteRenderer sprite;
    private Collider2D col;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(col);
            col.enabled = false;
            sprite.enabled = false;

            audioSource.clip = gemPickUpSound;
            audioSource.Play();

            Add();
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            sprite.enabled = false;

            audioSource.clip = gemPickUpSound;
            audioSource.Play();

            Add();
        }
    }
    private void Add()
    {
        GemsAmount.gemsAmount += 1;
    }
}
