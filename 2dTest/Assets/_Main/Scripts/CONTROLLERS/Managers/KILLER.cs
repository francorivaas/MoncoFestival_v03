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
            Debug.Log("MATAMOS AL PLAYER PAPA");
            Destroy(player);
        }

        if (collision.CompareTag("Player"))
        {
            Debug.Log("MATAMOS AL PLAYER PAPA, PERO CON UN RE TAG, RE DELLOOOOOOOL");
            Destroy(collision.gameObject);
        }
    }
}
