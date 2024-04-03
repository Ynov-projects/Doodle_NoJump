using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField] private GameObject bounceTrampoline;

    [SerializeField] private bool toActivate;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        bounceTrampoline.SetActive(!toActivate);
    }

    public void activate()
    {
        if (toActivate)
        {
            GetComponent<SpriteRenderer>().color = GameManager.activeColor;
            bounceTrampoline.SetActive(true);
        }
    }

    public void desactivate()
    {
        if (toActivate)
        {
            GetComponent<SpriteRenderer>().color = GameManager.inactiveColor;
            bounceTrampoline.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            animator.SetBool("isOn", true);
            AudioManager.Instance.PlayClip(clip);
        }
    }

    public void isOff()
    {
        animator.SetBool("isOn", false);
    }
}
