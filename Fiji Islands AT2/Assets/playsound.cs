using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            audioSource.Play();
        }
    }
}