using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int score = 0;

    public void AddScore(int value)
    {
        score += value;
        // Actualizar UI de puntuación
    }

    public void GameOver()
    {
        // Manejar lógica de fin del juego
    }

    public void ActivatePowerUp()
    {
        // Manejar lógica de power-up
    }
}
