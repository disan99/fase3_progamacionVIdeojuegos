using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI scoreText;

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
        gameOverPanel.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
