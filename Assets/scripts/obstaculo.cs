using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveDistance = 5f; 
    public float speed = 2f;        

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = startPosition + new Vector3(0, 0, offset);
    }
}
