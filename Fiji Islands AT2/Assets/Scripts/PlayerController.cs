using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private float time = 0.0f;
    private GameObject plusOne;
    private Vector3 oldPlusOnePos;
    private bool pickedUp = false;

    private int count;

    public float speed = 0;
    [SerializeField] public AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plusOne = GameObject.FindGameObjectWithTag("PlusOne");
        oldPlusOnePos = plusOne.transform.position;
        count = 0;
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

            count += 1;
        }
    }
}
