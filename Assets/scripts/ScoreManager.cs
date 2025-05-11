using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;
    public int hitCount = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        // Singleton para acceder fácilmente desde otros scripts
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddPoint()
    {
        score++;
        hitCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + score;
        }
    }
}
