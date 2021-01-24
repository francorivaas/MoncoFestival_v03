using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject ammoPickUpSound = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterAttack characterAttack = collision.GetComponent<CharacterAttack>();   

            if (characterAttack != null && characterAttack.currentAmmo < characterAttack.maxAmmo)
            {
                characterAttack.currentAmmo += 100;

                ammoPickUpSound.gameObject.SetActive(true);

                Destroy(gameObject, 1f);

                if (characterAttack.currentAmmo > characterAttack.maxAmmo)
                {
                    characterAttack.currentAmmo = characterAttack.maxAmmo;
                }
            }
        }
    }
}
