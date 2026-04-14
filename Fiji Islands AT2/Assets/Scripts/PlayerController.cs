using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector2 moveInput;

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

    // Make other button functions here

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

}
