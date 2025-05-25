using UnityEngine;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    public static SurvivalTimer Instance;

    public TextMeshProUGUI tiempoText; // Asignar desde el inspector

    private float timeSurvived = 0f;
    private bool isRunning = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isRunning)
        {
            timeSurvived += Time.deltaTime;
            if (tiempoText != null)
            {
                tiempoText.text = "" + GetFormattedTime();
            }
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetTime()
    {
        return timeSurvived;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(timeSurvived / 60f);
        int seconds = Mathf.FloorToInt(timeSurvived % 60f);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
