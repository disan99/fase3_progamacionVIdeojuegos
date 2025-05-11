using UnityEngine;

public class BloqueTrampa : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mostrar pantalla de muerte y pasar el puntaje actual
            GameOverManager.Instance.ShowGameOver(ScoreManager.Instance.score);

            // Opcional: destruir al jugador
            Destroy(collision.gameObject);
        }
    }
}
