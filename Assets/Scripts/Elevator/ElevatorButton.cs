using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject elevator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("pressed", true);
        elevator.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        elevator.GetComponent<ElevatorMovement>().active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("pressed", false);
        elevator.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        elevator.GetComponent<ElevatorMovement>().active = false;
    }
}
