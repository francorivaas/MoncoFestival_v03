using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEnemy : MonoBehaviour
{
    [SerializeField] 
    private float speed = 0.0f;

    private float lifeTime = 15.0f;
    private float currentLifeTime = 0.0f;

    private bool isMoving = false;

    [SerializeField]
    private GameObject slimeSound = null;

    private void Start()
    {
        isMoving = true;
    }

    void Update()
    {
        if (!CutsceneController.isCutsceneOn)
        {
            if (isMoving)
            {
                transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
                slimeSound.gameObject.SetActive(true);
            }

            currentLifeTime += Time.deltaTime;

            if (currentLifeTime >= lifeTime)
            {
                isMoving = false;
                Destroy(gameObject);
            }
        }
    }
}
