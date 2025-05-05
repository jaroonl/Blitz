using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] playlist;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private static MusicPlayer instance;


//Should allow for the music manager to persist between levels and screens
    void Awake()
    {
         if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
            return;
        }
    }
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
