using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;
    private Vector2 movement;
    private Vector2 moveInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnMove(InputValue value)
    {

        if (value != null)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded != false)
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision) => isGrounded = true;
    private void OnCollisionExit(Collision collision) => isGrounded = false;

    // Make other button functions here

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, rb.linearVelocity.y, moveInput.y);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

}
