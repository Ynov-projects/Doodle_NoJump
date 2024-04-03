using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject indication;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        indication.SetActive(false);
        if (gameObject.GetComponent<CapsuleCollider2D>().enabled && collision.transform.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = GameManager.activeColor;
            currentSceneManager.instance.spawnPoint = transform.position;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            AudioManager.Instance.PlayClip(clip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
            indication.SetActive(true);
    }
}
