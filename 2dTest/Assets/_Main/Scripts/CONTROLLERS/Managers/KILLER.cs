﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLER : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    private GameManager game;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*
            game.GameOver();
            */
        }
    }
}
