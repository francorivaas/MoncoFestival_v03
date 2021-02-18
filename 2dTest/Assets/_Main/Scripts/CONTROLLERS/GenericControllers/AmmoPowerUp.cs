using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterAttack characterAttack = collision.GetComponent<CharacterAttack>();   

            if (characterAttack != null && characterAttack.currentAmmo < characterAttack.maxAmmo)
            {
                characterAttack.currentAmmo += 100;

                Destroy(gameObject);

                if (characterAttack.currentAmmo > characterAttack.maxAmmo)
                {
                    characterAttack.currentAmmo = characterAttack.maxAmmo;
                }
            }
        }
    }
}
