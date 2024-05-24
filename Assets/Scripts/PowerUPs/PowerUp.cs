using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Otorgar habilidad especial al jugador
            GameManager.instance.ActivatePowerUp();
            // Desactivar o destruir power-up
            gameObject.SetActive(false);
        }
    }
}
