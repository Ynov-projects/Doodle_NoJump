using UnityEngine;

public class TeleportMe : MonoBehaviour
{
    [SerializeField] private GameObject teleportPosition;

    private bool isInTeleporter;

    private GameObject toTeleport;

    [SerializeField] private Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTeleporter)
        {
            animator.SetBool("isInTeleporter", true);
            if (toTeleport.tag == "Player") toTeleport.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInTeleporter = true;
            toTeleport = collision.gameObject;
        }
    }

    public void Teleport()
    {
        toTeleport.GetComponent<PlayerMovement>().enabled = true;
        toTeleport.transform.position = teleportPosition.transform.position;
        animator.SetBool("isInTeleporter", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInTeleporter = false;
            animator.SetBool("isInTeleporter", false);
        }
    }
}
