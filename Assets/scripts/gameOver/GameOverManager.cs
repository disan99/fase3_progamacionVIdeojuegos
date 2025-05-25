using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI timeText; // <- Añadido para mostrar el tiempo

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int finalScore)
    {
        scoreText.text = "Puntaje Final: " + finalScore;

        // Mostrar tiempo si SurvivalTimer está presente
        if (timeText != null && SurvivalTimer.Instance != null)
        {
            SurvivalTimer.Instance.StopTimer(); // Detener el cronómetro
            timeText.text = "Tiempo sobrevivido: " + SurvivalTimer.Instance.GetFormattedTime();
        }

        gameOverPanel.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
