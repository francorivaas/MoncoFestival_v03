using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [Header("Parameters & Components")]

    public static int enemiesKilled = 0;

    public bool canRecover = false;

    [SerializeField]
    private GameObject healthPowerUpSound = null;

    private void Start()
    {
        healthPowerUpSound.gameObject.SetActive(false);
        canRecover = false;
    }

    private void Update()
    {
        if (enemiesKilled == 10)
        {
            healthPowerUpSound.gameObject.SetActive(true);
            
            canRecover = true;

            enemiesKilled = 0;
        }
            
        else if (enemiesKilled < 10 || enemiesKilled > 10)
        {
            healthPowerUpSound.gameObject.SetActive(false);
            canRecover = false;
        }
             
    }
}
