using UnityEngine;

public class LegBreaker : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.instance.canJump = false;
        AudioManager.Instance.PlayClip(clip);
    }
}
