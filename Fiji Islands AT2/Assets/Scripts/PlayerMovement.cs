using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 1000f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey (KeyCode.W))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
}
}