using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int maxHealth = 100; // Vida m�xima del jugador
    private int currentHealth; // Vida actual del jugador
    public Text healthText; // Texto para mostrar la vida del jugador
    public GameObject gameOverUI; // Referencia al objeto de la interfaz de usuario para Game Over
    public Transform respawnPoint; // Punto de reaparici�n del jugador

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida del jugador al m�ximo al inicio del juego
        UpdateHealthUI(); // Actualizar el texto de la vida en la UI
    }

    void Update()
    {
        // Obtener la entrada del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la direcci�n de movimiento
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Aplicar el movimiento en Update para una respuesta m�s r�pida a la entrada
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    // M�todo para reducir la vida del jugador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del jugador
        UpdateHealthUI(); // Actualizar el texto de la vida en la UI

        if (currentHealth <= 0)
        {
            Die(); // Llamar al m�todo de muerte si la vida del jugador llega a cero o menos
        }
    }

    // M�todo para actualizar el texto de la vida en la interfaz de usuario
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString(); // Actualizar el texto con la vida actual del jugador
    }

    // M�todo para manejar la muerte del jugador
    void Die()
    {
        // Reiniciar el nivel volviendo a cargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Activar el objeto de la interfaz de usuario para Game Over
        gameOverUI.SetActive(true);

        // Restablecer la posici�n del jugador al punto de reaparici�n
        transform.position = respawnPoint.position;
    }
}

