using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            Destroy(gameObject); 
        }
    }
}
