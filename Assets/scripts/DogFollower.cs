using UnityEngine;

public class DogFollower : MonoBehaviour
{
    public Transform target;         // El jugador
    public float speed = 3.5f;
    public float stoppingDistance = 1f;
    public Transform visual;         // El hijo con el modelo del perro

    void Update()
    {
        if (target == null || visual == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        // Movimiento
        if (distance > stoppingDistance)
        {
            transform.position += direction * speed * Time.deltaTime;

            // Orientar solo visualmente en el plano horizontal y bloquear la rotación en X
            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            if (lookDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(lookDirection);
                Quaternion visualRotation = visual.rotation;
                Quaternion targetRotation = Quaternion.Euler(visualRotation.eulerAngles.x, toRotation.eulerAngles.y, visualRotation.eulerAngles.z);
                visual.rotation = Quaternion.Slerp(visualRotation, targetRotation, 10f * Time.deltaTime);
            }
        }
        else
        {
            // Opcional: Asegurar que mire al jugador cuando se detiene (bloqueando la rotación en X)
            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            if (lookDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(lookDirection);
                Quaternion visualRotation = visual.rotation;
                Quaternion targetRotation = Quaternion.Euler(visualRotation.eulerAngles.x, toRotation.eulerAngles.y, visualRotation.eulerAngles.z);
                visual.rotation = Quaternion.Slerp(visualRotation, targetRotation, 10f * Time.deltaTime);
            }
        }
    }
}