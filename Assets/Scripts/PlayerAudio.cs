using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip shootClip;

    public AudioClip thrustClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShoot()
    {
        audioSource.clip = shootClip;
        audioSource.Play();
    }

    public void PlayThrust()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = thrustClip;
            audioSource.Play();
        }
    }
}