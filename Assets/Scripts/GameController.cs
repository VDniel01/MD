using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public GameObject interfazInicioOleada; // Objeto de la interfaz de inicio de oleada
    public Text textoNumeroOleada; // Texto para mostrar el número de la oleada actual
    private bool gameOver = false;
    private int oleadaActual = 1;
    public int cantidadEnemigosPorOleada = 5; // Cantidad de enemigos por oleada
    public GameObject enemigoPrefab; // Prefab del enemigo

    void Start()
    {
        interfazInicioOleada.SetActive(false); // Desactiva la interfaz de inicio de oleada al inicio del juego
    }

    // Método para avanzar a la siguiente oleada
    void AvanzarSiguienteOleada()
    {
        oleadaActual++; // Aumentar el número de la oleada
        MostrarInterfazInicioOleada(); // Mostrar la interfaz de inicio de la siguiente oleada
        Invoke("IniciarSiguienteOleada", 3f); // Esperar 3 segundos antes de iniciar la siguiente oleada
    }

    // Método para iniciar la siguiente oleada
    void IniciarSiguienteOleada()
    {
        // Lógica para instanciar la siguiente oleada de enemigos
        for (int i = 0; i < cantidadEnemigosPorOleada; i++)
        {
            Instantiate(enemigoPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    // Método para mostrar la interfaz de inicio de la siguiente oleada
    void MostrarInterfazInicioOleada()
    {
        // Lógica para mostrar la interfaz de inicio de oleada
        interfazInicioOleada.SetActive(true); // Activa un objeto de interfaz que contiene un texto indicando el número de la oleada actual
        textoNumeroOleada.text = "Oleada " + oleadaActual; // Actualiza el texto para que muestre el número de la oleada actual
    }

    // Función para obtener una posición aleatoria para spawnear enemigos
    Vector3 GetRandomSpawnPosition()
    {
        // Definir los límites del área donde se pueden generar enemigos
        float minX = -10f;
        float maxX = 10f;
        float minY = -5f;
        float maxY = 5f;

        // Generar una posición aleatoria dentro de los límites
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Devolver la posición como un Vector3 con la coordenada Z en 0 (plano XY)
        return new Vector3(randomX, randomY, 0f);
    }
}

