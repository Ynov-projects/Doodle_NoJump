using UnityEngine;

public class Ladder : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private GameObject indicationUpDown;

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
            indicationUpDown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            indicationUpDown.SetActive(false);
            playerMovement.isClimbing = false;
        }
    }
}