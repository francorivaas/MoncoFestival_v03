using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [Header("Parameters & Components")]

    public static int enemiesKilled = 0;

    [SerializeField]
    private LifeController lifeController;

    public bool canRecover = false;

    private void Awake()
    {
    }

    private void Start()
    {
        canRecover = false;
    }

    private void Update()
    {
        Debug.Log(enemiesKilled);

        if (enemiesKilled == 10)
        {
            canRecover = true;
        }
        else
        {
            canRecover = false;
        }  
    }
}
