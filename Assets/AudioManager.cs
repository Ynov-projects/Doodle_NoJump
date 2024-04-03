using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource dialogSource;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    public void PlayClip(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.Play();
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
