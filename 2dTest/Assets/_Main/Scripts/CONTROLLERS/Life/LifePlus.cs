using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlus : MonoBehaviour
{
    [SerializeField]
    private LifeController lifeController = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("cual segun el world");
            lifeController.currentLife = lifeController.currentLife += 10.0f;
        }
    }
}
