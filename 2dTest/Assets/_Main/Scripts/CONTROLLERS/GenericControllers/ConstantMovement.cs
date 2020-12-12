using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    void Update()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
    }
}
