using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Debug.Log("CUAL PAPA TE DESTRUIS O NO");
            Destroy(collision.gameObject);
        }
    }
}
