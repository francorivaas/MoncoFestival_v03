using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    [SerializeField]
    private GameObject spawner1 = null;

    [SerializeField]
    private GameObject spawner2 = null;

    [SerializeField]
    private GameObject spawner3 = null;

    [SerializeField]
    private GameObject spawner4 = null;

    [SerializeField]
    private GameObject spawner5 = null;

    [SerializeField]
    private GameObject spawner6 = null;

    [SerializeField]
    private bool deactivate = false;

    void Update()
    {
        if (deactivate)
        {
            spawner1.gameObject.SetActive(false);
            spawner2.gameObject.SetActive(false);
            spawner3.gameObject.SetActive(false);
            spawner4.gameObject.SetActive(false);
            spawner5.gameObject.SetActive(false);
            spawner6.gameObject.SetActive(false);
        }
        else
        {
            spawner1.gameObject.SetActive(true);
            spawner2.gameObject.SetActive(true);
            spawner3.gameObject.SetActive(true);
            spawner4.gameObject.SetActive(true);
            spawner5.gameObject.SetActive(true);
            spawner6.gameObject.SetActive(true);
        }
    }
}
