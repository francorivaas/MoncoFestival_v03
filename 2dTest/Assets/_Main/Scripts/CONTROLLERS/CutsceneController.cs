using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public static bool isCutsceneOn = false;

    //Timer
    private float timeToDeactivate = 4.0f;
    private float currentTimeToDeactivate = 0.0f;

    private bool canCount = false;

    private void Start()
    {
        isCutsceneOn = true;
    }

    private void Update()
    {
        if (canCount)
        {
            currentTimeToDeactivate += Time.deltaTime;

            if (currentTimeToDeactivate >= timeToDeactivate)
            {
                isCutsceneOn = false;
                Destroy(gameObject, 0.2f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            isCutsceneOn = true;
            canCount = true;
        }
    }
}
