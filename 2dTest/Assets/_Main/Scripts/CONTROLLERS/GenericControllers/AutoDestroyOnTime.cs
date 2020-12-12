using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyOnTime : MonoBehaviour
{
    [SerializeField]
    private float maxLife = 5.0f;

    [SerializeField]
    private float currentLife = 0.0f;

    void Update()
    {
        currentLife += Time.deltaTime;

        if (currentLife >= maxLife)
        {
            Destroy(gameObject);
        }
    }
}
