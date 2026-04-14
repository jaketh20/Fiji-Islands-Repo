using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField] public AudioClip clip;
    float time = 0.0f;
    GameObject plusOne;
    Vector3 oldPlusOnePos;
    bool pickedUp = false;

    public float speed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plusOne = GameObject.FindGameObjectWithTag("PlusOne");
        oldPlusOnePos = plusOne.transform.position;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (time < 1.0f & pickedUp)
        {
            time += Time.deltaTime;
            plusOne.transform.position += new Vector3(0,0.01f,0);
        }
        else
        {
            plusOne.transform.position = oldPlusOnePos;
            time = 0.0f;
            pickedUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            //there HAS to be a better way to do this, surely
            AudioSource.PlayClipAtPoint(clip, transform.position);
            plusOne.transform.position = other.transform.position;
            pickedUp = true;

            other.gameObject.SetActive(false);
        }
    }
}
