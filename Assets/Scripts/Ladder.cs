using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange = false;
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
        {
            playerMovement.isClimbing = false;
            return;
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            playerMovement.isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
        }
    }
}