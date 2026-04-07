using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // How many seconds before the object deletes itself
    public float countdown = 3f;

    void Update()
    {
        // Subtract time each frame
        countdown -= Time.deltaTime;

        // When countdown reaches zero delete the object
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
}