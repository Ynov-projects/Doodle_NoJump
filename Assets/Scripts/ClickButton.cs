using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject elevator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("pressed", true);
        elevator.GetComponent<ElevatorMovement>().active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("pressed", false);
        elevator.GetComponent<ElevatorMovement>().active = false;
    }
}
