using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLER : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController player = GetComponent<CharacterController>();

        if (player != null)
        {
            Destroy(player);
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
