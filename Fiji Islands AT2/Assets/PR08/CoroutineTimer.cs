using UnityEngine;
using System.Collections;

public class CoroutineTimer : MonoBehaviour
{
    // How many seconds before the object deletes itself
    public float delay = 3f;

    void Start()
    {
        // Start the coroutine when the object is created
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        // Wait for the delay time
        yield return new WaitForSeconds(delay);
        // Then destroy this object
        Destroy(gameObject);
    }
}