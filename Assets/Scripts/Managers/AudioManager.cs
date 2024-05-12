using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource dialogSource;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void ChangeMusic(AudioClip clip)
    {
        if (musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (!soundSource.isPlaying)
        {
            soundSource.clip = clip;
            soundSource.Play();
        }
    }

    public void PlayDialog(AudioClip dialog)
    {
        dialogSource.clip = dialog;
        dialogSource.Play();
    }

    public void StopDialog()
    {
        dialogSource.Stop();
    }
}
