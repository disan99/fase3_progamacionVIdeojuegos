        using UnityEngine;

        public class PlayerCoinCollector : MonoBehaviour
        {
            void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Moneda"))
                {
                    ScoreManager.Instance.AddPoint();
                    Destroy(other.gameObject);

                    // Verifica si quedan monedas en la escena
                    if (GameObject.FindGameObjectsWithTag("Moneda").Length == 1) // Solo queda esta
                    {
                        GameOverManager.Instance.ShowGameOver(ScoreManager.Instance.score);
                    GetComponent<PlayerMovement>().enabled = false;
                    }
                }
            }
        }
