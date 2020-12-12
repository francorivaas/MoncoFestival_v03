using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorController : MonoBehaviour
{
    [SerializeField]
    private GameObject genericGameObject = null;

    public float timeToInstantiate = 0.0f;

    [SerializeField]
    private float currentTimeToInstantiate = 0.0f;

    private void Start()
    {
        currentTimeToInstantiate = timeToInstantiate;
    }

    private void Update()
    {
        currentTimeToInstantiate += Time.deltaTime;

        if (currentTimeToInstantiate >= timeToInstantiate)
        {
            Instantiate(genericGameObject, transform.position, Quaternion.identity);

            Restart();
        }
    }

    void Restart()
    {
        currentTimeToInstantiate = 0.0f;
    }
}
