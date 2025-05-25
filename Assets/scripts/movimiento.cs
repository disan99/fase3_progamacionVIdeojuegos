using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.3f;
    public float jumpForce = 8f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1.2f;

    public Transform visualModel; // Asignar en el inspector
    private Animator animator;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = visualModel.GetComponent<Animator>();

    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
        animator.SetFloat("velX", h);
        animator.SetFloat("vely", v);

        // Animación de caminar
        if (animator != null)
        {
            animator.SetFloat("Speed", move.magnitude);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Rotar el modelo hacia la dirección del movimiento
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            visualModel.rotation = Quaternion.Slerp(visualModel.rotation, toRotation, 10f * Time.deltaTime);
        }
    }
 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
