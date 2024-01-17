using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private Transform _elevator;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    [SerializeField] private GameObject elevator;

    [SerializeField] private float _speed;
    private bool active = true;

    void Update()
    {
        if (active)
        {
            _elevator.transform.position = Vector3.Lerp(
                _startPos.position,
                _endPos.position,
                Mathf.PingPong(Time.time / _speed, 1));
        }
    }

    public void activate()
    {
        active = true;
        elevator.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void desactivate()
    {
        active = false;
        elevator.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
