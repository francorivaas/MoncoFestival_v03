using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private GameObject three = null;

    [SerializeField]
    private GameObject two = null;

    [SerializeField]
    private GameObject one = null;

    [SerializeField]
    private GameObject ksb = null;

    private float countdown = 3.0f;
    private float currentCountdown = 0.0f;

    private bool canCount = false;

    void Start()
    {
        currentCountdown = countdown;

        three.gameObject.SetActive(true);

        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        ksb.gameObject.SetActive(false);

        canCount = true;
    }


    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 2)
        {
            two.SetActive(true);

            one.SetActive(false);
            three.SetActive(false);
            ksb.gameObject.SetActive(false);
            
        }

        if (countdown <= 1)
        {
            one.SetActive(true);

            three.SetActive(false);
            two.SetActive(false);
            ksb.gameObject.SetActive(false);
        }

        if (countdown <= 0.0)
        {
            ksb.gameObject.SetActive(true);
            one.gameObject.SetActive(false);

            Destroy(gameObject, 1.0f);
        }
    }
}
