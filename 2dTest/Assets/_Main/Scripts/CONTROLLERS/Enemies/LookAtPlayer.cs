using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] 
    private Transform player = null;
    
    void Update()
    {
        transform.LookAt(player);
    }
}
