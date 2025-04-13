using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public GameObject coinPrefab;          
    public Vector3 coinOffset = new Vector3(0, 1f, 0); 
    public float bounceAmount = 0.2f;
    public float bounceSpeed = 4f;
    public float coinLifetime = 1.0f;

    private Vector3 originalPosition;
    private bool isBouncing = false;
    private float bounceTimer = 0f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBouncing)
        {
            isBouncing = true;
            bounceTimer = 0f;
            SpawnCoin();
        }
    }

    void Update()
    {
        if (isBouncing)
        {
            bounceTimer += Time.deltaTime * bounceSpeed;
            float displacement = Mathf.Sin(bounceTimer * Mathf.PI) * bounceAmount;
            transform.position = originalPosition + Vector3.up * displacement;

            if (bounceTimer >= 1f)
            {
                transform.position = originalPosition;
                isBouncing = false;
            }
        }
    }

    void SpawnCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position + coinOffset, Quaternion.identity);
        Destroy(coin, coinLifetime);
    }
}

