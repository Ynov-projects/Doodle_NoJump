using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorMovement : MonoBehaviour
{

    [SerializeField] private Transform[] checkpoints;
    private int index = 0;
    private Transform destination;

    [SerializeField] private GameObject elevator;
    private Rigidbody2D rb;

    [SerializeField] private float Speed;
    public bool active;

    void Start()
    {
        destination = checkpoints[index];
        rb = elevator.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(elevator.transform.position, destination.position);
        float y = destination.position.y - elevator.transform.position.y;
        if (y > 0 && active)
        {
            rb.velocity = Vector2.up * Speed;
        }
        else if (y < 0 && active)
        {
            rb.velocity = Vector2.down * Speed;
        }

        if (distance < 0.3f)
        {
            index = (index + 1) % checkpoints.Length;
            destination = checkpoints[index];
            elevator.transform.localScale = new Vector2(-elevator.transform.localScale.x, elevator.transform.localScale.y);
        }
        else
        {

        }
    }
}
