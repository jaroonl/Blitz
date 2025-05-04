using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] playlist;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    void Update()
    {
        // If the current song finished, play the next one
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        if (playlist.Length == 0) return;

        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();

        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length; // Loop back to first track
    }
}
