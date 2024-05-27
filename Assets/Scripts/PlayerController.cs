using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int maxHealth = 100; // Vida máxima del jugador
    private int currentHealth; // Vida actual del jugador
    public Text healthText; // Texto para mostrar la vida del jugador
    public GameObject gameOverUI; // Referencia al objeto de la interfaz de usuario para Game Over
    public Transform respawnPoint; // Punto de reaparición del jugador

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida del jugador al máximo al inicio del juego
        UpdateHealthUI(); // Actualizar el texto de la vida en la UI
    }

    void Update()
    {
        // Obtener la entrada del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Aplicar el movimiento en Update para una respuesta más rápida a la entrada
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    // Método para reducir la vida del jugador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del jugador
        UpdateHealthUI(); // Actualizar el texto de la vida en la UI

        if (currentHealth <= 0)
        {
            Die(); // Llamar al método de muerte si la vida del jugador llega a cero o menos
        }
    }

    // Método para actualizar el texto de la vida en la interfaz de usuario
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString(); // Actualizar el texto con la vida actual del jugador
    }

    // Método para manejar la muerte del jugador
    void Die()
    {
        // Reiniciar el nivel volviendo a cargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Activar el objeto de la interfaz de usuario para Game Over
        gameOverUI.SetActive(true);

        // Restablecer la posición del jugador al punto de reaparición
        transform.position = respawnPoint.position;
    }
}

