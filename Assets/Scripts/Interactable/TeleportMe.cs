using System.Collections;
using UnityEngine;

public class TeleportMe : MonoBehaviour
{
    [SerializeField] private GameObject teleportPosition;

    private bool isInTeleporter;

    private GameObject toTeleport;
    [SerializeField] private GameObject indication;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject level;

    [SerializeField] private AudioClip clip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTeleporter)
        {
            if (toTeleport.tag == "Player")
            {
                animator.SetBool("readyToMove", true);
                AudioManager.Instance.PlayClip(clip);
                StartCoroutine(DesactivatePlayer());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indication.SetActive(true);
            isInTeleporter = true;
            toTeleport = collision.gameObject;

        }
    }

    public void Teleport()
    {
        if (level != null) level.SetActive(true);

        toTeleport.GetComponent<PlayerMovement>().enabled = true;
        toTeleport.transform.position = teleportPosition.transform.position;
        animator.SetBool("readyToMove", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            indication.SetActive(false);
            isInTeleporter = false;
            animator.SetBool("readyToMove", false);
        }
    }

    private IEnumerator DesactivatePlayer()
    {
        toTeleport.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForEndOfFrame();
        toTeleport.GetComponent<PlayerMovement>().enabled = false;
    }
}