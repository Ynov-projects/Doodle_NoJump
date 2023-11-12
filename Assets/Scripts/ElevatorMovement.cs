using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{

    public Transform[] checkpoints;
    int index = 0;

    Transform destination;
    public GameObject elevator;
    Rigidbody2D rb;

    public float Speed;

    void Start()
    {
        destination = checkpoints[index];
        rb = elevator.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float y = destination.position.y - elevator.transform.position.y;
        if(y > 0)
        {
            rb.velocity = Vector2.up * Speed;
        }else if(y < 0)
        {
            rb.velocity = Vector2.down * Speed;
        }

        if (Vector2.Distance(elevator.transform.position, destination.position) < 0.3f)
        {
            index = (index + 1) % checkpoints.Length;
            destination = checkpoints[index];
            elevator.transform.localScale = new Vector2(-elevator.transform.localScale.x, elevator.transform.localScale.y);
        }
    }
}
