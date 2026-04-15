using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {
        if (sounds.Length > 0)
        {
            int randomIndex = Random.Range(0, sounds.Length);

            audioSource.clip = sounds[randomIndex];
            audioSource.Play();
        }
    }
}
