using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aumentar puntuación del jugador
            GameManager.instance.AddScore(1);
            // Desactivar o destruir moneda
            gameObject.SetActive(false);
        }
    }
}

