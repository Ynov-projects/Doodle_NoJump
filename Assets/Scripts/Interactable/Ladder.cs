using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject indicationUpDown;

    private bool isInTrigger;

    void Update()
    {
        Vector2 movement = GameManager.input.Gameplay.Movement.ReadValue<Vector2>();
        if (movement.x > 0.3f)
        {
            PlayerMovement.instance.isClimbing = false;
            return;
        }

        if (movement.y > 0.1f && isInTrigger)
            PlayerMovement.instance.isClimbing = true;

        if(!isInTrigger) PlayerMovement.instance.isClimbing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("LegPlayer"))
        {
            isInTrigger = true;
            indicationUpDown.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            indicationUpDown.SetActive(false);
            isInTrigger = false;
        }
    }
}