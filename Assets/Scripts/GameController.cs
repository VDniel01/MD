using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject winUI;
    private bool gameOver = false;

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Win()
    {
        winUI.SetActive(true);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

