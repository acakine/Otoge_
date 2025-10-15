using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public float GetMusicTime()
    {
        return audioSource.time;
    }
}
