using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveDistance = 5f;
    public float baseSpeed = 2f;
    public float speedMultiplier = 0.4f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float currentSpeed = baseSpeed + (ScoreManager.Instance != null ? ScoreManager.Instance.score * speedMultiplier : 0f);
        float offset = Mathf.Sin(Time.time * currentSpeed) * moveDistance;
        transform.position = startPosition + new Vector3(0, 0, offset);
    }
}
