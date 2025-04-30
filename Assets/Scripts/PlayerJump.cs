using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   public AudioClip jumpSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSounds[index]);
    }
}
