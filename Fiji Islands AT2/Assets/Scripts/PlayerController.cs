using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Material redMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private float camSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody camRb;

    private Vector3 movement;
    private Vector2 moveInput;
    private Vector2 mouseMovement;
    private Rigidbody rb;
    private Renderer rend;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }


    void OnMove(InputValue value)
    {

        if (value != null)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnLook(InputValue value)
    {
        if (value != null)
        {
            mouseMovement = value.Get<Vector2>();

            float mouseMovementX = mouseMovement.x;
            float mouseMovementY = mouseMovement.y;

        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded != false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnChangeColour(InputValue value)
    {
        if (value != null)
        {
            if (rend.sharedMaterial == redMat)
            {
                rend.sharedMaterial = greenMat;
            }
            else if (rend.sharedMaterial == greenMat)
            {
                rend.sharedMaterial = redMat;
            }
        }
    }

    private void OnCollisionStay(Collision collision) => isGrounded = true;
    private void OnCollisionExit(Collision collision) => isGrounded = false;

    // Make other button functions here

    void FixedUpdate()
    {
        movement = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

        // camRb.MoveRotation()
    }

}
