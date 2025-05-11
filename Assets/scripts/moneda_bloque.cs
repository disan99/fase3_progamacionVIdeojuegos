using UnityEngine;
using TMPro;

public class CoinBlock : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector3 posicionA = new Vector3(20.48f, 7.89f, 0f);
    public Vector3 posicionB = new Vector3(4.2f, 7.89f, 0f);
    public float coinLifetime = 1.0f;
    public float tiempoDeReaparicion = 0.5f; // Tiempo en segundos antes de reaparecer
    private AudioSource golpeSonido; // Referencia al componente Audio Source

    private bool enPosicionA = true;
    private bool haSidoGolpeado = false;
    private Collider blockCollider;
    private MeshRenderer blockRenderer;

    void Start()
    {
        blockCollider = GetComponent<Collider>();
        blockRenderer = GetComponent<MeshRenderer>();
        golpeSonido = GetComponent<AudioSource>(); // Obtener el Audio Source del cubo

        if (blockCollider == null || blockRenderer == null || golpeSonido == null)
        {
            Debug.LogError("El bloque necesita un Collider, un MeshRenderer y un Audio Source.");
            enabled = false;
        }

        // Establecer la posición inicial al arrancar el juego
        transform.position = posicionA;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !haSidoGolpeado)
        {
            haSidoGolpeado = true;

            ScoreManager.Instance.AddPoint();

            ReproducirSonidoGolpe(); // Llamar a la función para reproducir el sonido
            SpawnCoin();
            DesactivarBloque();
            Invoke("ReaparecerBloque", tiempoDeReaparicion);
        }
    }

    void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
            Destroy(coin, coinLifetime);
        }
        else
        {
            Debug.LogWarning("El Prefab de la moneda no está asignado.");
        }
    }

    void DesactivarBloque()
    {
        if (blockCollider != null)
        {
            blockCollider.enabled = false; // Desactivar el collider
        }
        if (blockRenderer != null)
        {
            blockRenderer.enabled = false; // Hacer el bloque invisible
        }
    }

    void ReaparecerBloque()
    {
        if (enPosicionA)
        {
            transform.position = posicionB;
        }
        else
        {
            transform.position = posicionA;
        }

        enPosicionA = !enPosicionA; // Cambiar la posición para el siguiente golpe
        haSidoGolpeado = false;
        if (blockCollider != null)
        {
            blockCollider.enabled = true; // Reactivar el collider
        }
        if (blockRenderer != null)
        {
            blockRenderer.enabled = true; // Hacer el bloque visible nuevamente
        }
    }

    void ReproducirSonidoGolpe()
    {
        if (golpeSonido != null)
        {
            golpeSonido.Play(); // Reproduce el sonido asignado al Audio Source
        }
        else
        {
            Debug.LogWarning("El componente Audio Source no se encontró en el bloque.");
        }
    }
}