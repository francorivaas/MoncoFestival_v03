using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [Header("Parameters & Components")]

    public static int enemiesKilled = 0;

    public bool canRecover = false;

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

            enemiesKilled = 0;
        }
            

        else if (enemiesKilled < 10 || enemiesKilled > 10)
        {
            canRecover = false;
        }
            
    }
}
