using UnityEngine;

public class BreakableBlockReaction : MonoBehaviour
{
    public float bounceForce = 5f; 
    public float bounceDuration = 0.2f; 
    public Vector3 bounceDirection = Vector3.up; 

    private Vector3 originalPosition;
    private float timer;
    private bool isBouncing;

    void Start()
    {
        originalPosition = transform.position; 
    }

    void Update()
    {
        if (isBouncing)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / bounceDuration); 

            /
            float yOffset = Mathf.Sin(t * Mathf.PI) * bounceForce;
            transform.position = originalPosition + bounceDirection * yOffset;

            if (t >= 1f)
            {
                isBouncing = false;
                transform.position = originalPosition; /
            }
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBouncing)
        {
            StartBounce();
        }
    }

    void StartBounce()
    {
        isBouncing = true;
        timer = 0f;
    }
}