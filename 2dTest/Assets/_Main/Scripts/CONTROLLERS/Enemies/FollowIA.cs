﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float stopDistance = 0.5f;

    private Transform player;

    [SerializeField] private GameObject buzzSound = null;

    private void Awake()
    {

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        buzzSound.gameObject.SetActive(true);
    }

    private void Update()
    {        
        if (!CutsceneController.isCutsceneOn)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;

                buzzSound.gameObject.SetActive(true);
            }

            if (transform.position.x > player.position.x)
                transform.rotation = Quaternion.identity;

            else if (transform.position.x < player.position.x)
                transform.Rotate(180, 0, 180);
        }        
    }
}

