using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    public GameObject pantallaInicio; // Asigna el panel completo de la pantalla de inicio

    void Start()
    {
        Time.timeScale = 0f; // Pausar el juego al inicio
    }

    public void EmpezarJuego()
    {
        pantallaInicio.SetActive(false);
        Time.timeScale = 1f; // Reanudar el juego
    }
}
