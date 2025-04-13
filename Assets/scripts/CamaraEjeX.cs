using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform target; 
    public float offsetX = 0f; 

    private Vector3 initialPosition;

   
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = transform.position;

            
            newPosition.x = target.position.x + offsetX;

            transform.position = new Vector3(newPosition.x, initialPosition.y, initialPosition.z);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objetivo (jugador) a la cámara.");
        }
    }

   
    void Start()
    {
       
        initialPosition = transform.position;

        if (target == null)
        {
            Debug.LogError("Por favor, asigna el Transform del jugador al campo 'Target' en el Inspector de la cámara.");
            enabled = false;
        }
    }
}